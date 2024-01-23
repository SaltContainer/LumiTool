using AssetsTools.NET;
using AssetsTools.NET.Extra;
using LumiTool.Data;
using LumiTool.Forms;
using static System.Windows.Forms.DataFormats;

namespace LumiTool.Engine
{
    public class LumiToolEngine
    {
        private AssetsManager manager;
        private TemplateFieldToTypeTree typeTreeConverter;

        public LumiToolEngine()
        {
            manager = new AssetsManager();
            typeTreeConverter = new TemplateFieldToTypeTree();
        }

        public void UnloadBundles()
        {
            manager.UnloadAll();
        }

        public BundleFileInstance LoadBundle(string path)
        {
            return manager.LoadBundleFile(path, true);
        }

        public AssetsFileInstance LoadAssetsFileFromBundle(BundleFileInstance bundle)
        {
            return manager.LoadAssetsFileFromBundle(bundle, 0, false);
        }

        public void SetAssetsFileInBundle(BundleFileInstance bundle, AssetsFileInstance assetsFile)
        {
            bundle.file.BlockAndDirInfo.DirectoryInfos[0].SetNewData(assetsFile.file);
        }

        public void SetPlatformOfBundle(BundleFileInstance bundle, AssetsFileInstance assetsFile, Platform platform)
        {
            assetsFile.file.Metadata.TargetPlatform = Convert.ToUInt32(platform);
            SetAssetsFileInBundle(bundle, assetsFile);
        }

        public void SaveBundleToFile(BundleFileInstance bundle, string path)
        {
            using (AssetsFileWriter writer = new AssetsFileWriter(path))
            {
                bundle.file.Write(writer);
            }
        }

        public bool AddMonoScript(BundleFileInstance bundle, AssetsFileInstance assetsFile, string assembly, string namezpace, string klass)
        {
            AssetsFile file = assetsFile.file;

            manager.LoadClassPackage("classdata.tpk");
            var cldb = manager.LoadClassDatabaseFromPackage(file.Metadata.UnityVersion);

            Random rand = new Random();
            var monoScriptPathId = rand.NextInt64();

            var monoScriptClassId = (int)AssetClassID.MonoScript;
            var monoScriptInfo = AssetFileInfo.Create(file, monoScriptPathId, monoScriptClassId, cldb);
            file.Metadata.AssetInfos.Add(monoScriptInfo);

            var monoScriptTemp = manager.GetTemplateBaseField(assetsFile, monoScriptInfo);
            var monoScriptBf = ValueBuilder.DefaultValueFieldFromTemplate(monoScriptTemp);
            monoScriptBf["m_Name"].AsString = klass;
            monoScriptBf["m_ClassName"].AsString = klass;
            monoScriptBf["m_Namespace"].AsString = namezpace;
            monoScriptBf["m_AssemblyName"].AsString = assembly;

            monoScriptInfo.SetNewData(monoScriptBf);

            var newScriptId = file.Metadata.ScriptTypes.Count;

            file.Metadata.ScriptTypes.Add(new AssetPPtr(0, monoScriptPathId));

            var monoBehaviourClassId = (int)AssetClassID.MonoBehaviour;
            var monoBehaviourTemp = manager.GetTemplateBaseField(assetsFile, null, 0, monoBehaviourClassId, (ushort)newScriptId, AssetReadFlags.SkipMonoBehaviourFields);

            manager.MonoTempGenerator = new MonoCecilTempGenerator("Managed");
            var newBaseField = manager.MonoTempGenerator.GetTemplateField(monoBehaviourTemp, assembly, namezpace, klass, new UnityVersion(file.Metadata.UnityVersion));

            if (newBaseField != null)
            {
                var newTypeTreeItem = ConvertTemplateFieldToTypeTree(cldb, newBaseField, monoBehaviourClassId, (ushort)newScriptId);

                file.Metadata.TypeTreeTypes.Add(newTypeTreeItem);

                var fileOutStream = new MemoryStream();
                var fileOutWriter = new AssetsFileWriter(fileOutStream);
                file.Write(fileOutWriter);
                bundle.file.BlockAndDirInfo.DirectoryInfos[0].Replacer = new ContentReplacerFromBuffer(fileOutStream.ToArray());

                return true;
            }
            else
            {
                return false;
            }

        }

        public void CopyMaterials(AssetsFileInstance to, AssetsFileInstance from)
        {
            var toMats = to.file.GetAssetsOfType(AssetClassID.Material);
            var fromMats = from.file.GetAssetsOfType(AssetClassID.Material);
            foreach (var fromMat in fromMats)
            {
                var fromMatBase = manager.GetBaseField(from, fromMat);
                var toMat = toMats.Find(m => manager.GetBaseField(to, m)["m_Name"].AsString == fromMatBase["m_Name"].AsString);
                if (toMat != null)
                {
                    var toMatBase = manager.GetBaseField(to, toMat);
                    CopyMaterial(toMat, fromMatBase);
                }
            }

            SetAssetsFileInBundle(to.parentBundle, to);
        }

        public void CopyDependencies(AssetsFileInstance to, AssetsFileInstance from)
        {
            ClearDependencies(to);
            foreach (var dep in from.file.Metadata.Externals)
                to.file.Metadata.Externals.Add(dep);

            SetAssetsFileInBundle(to.parentBundle, to);
        }

        public void RepointTexturesOfMaterials(AssetsFileInstance to, AssetsFileInstance from)
        {
            var toMats = to.file.GetAssetsOfType(AssetClassID.Material);
            var fromMats = from.file.GetAssetsOfType(AssetClassID.Material);
            var toTexs = to.file.GetAssetsOfType(AssetClassID.Texture2D);

            foreach (var fromMat in fromMats)
            {
                var fromMatBase = manager.GetBaseField(from, fromMat);
                var toMat = toMats.Find(m => manager.GetBaseField(to, m)["m_Name"].AsString == fromMatBase["m_Name"].AsString);
                if (toMat != null)
                {
                    var toMatBase = manager.GetBaseField(to, toMat);
                    var toTexsOfMat = toMatBase["m_SavedProperties"]["m_TexEnvs"]["Array"];

                    foreach (var toTexOfMat in toTexsOfMat)
                    {
                        long original = toTexOfMat["second"]["m_Texture"]["m_PathID"].AsLong;
                        if (original == 0)
                            continue;

                        var fromTex = manager.GetBaseField(from, original);

                        var toTex = toTexs.Find(t => manager.GetBaseField(to, t)["m_Name"].AsString == fromTex["m_Name"].AsString);
                        if (toTex != null)
                            toTexOfMat["second"]["m_Texture"]["m_PathID"].AsLong = toTex.PathId;
                    }

                    toMat.SetNewData(toMatBase);
                }
            }

            SetAssetsFileInBundle(to.parentBundle, to);
        }

        public void AssignDataToNewMaterials(AssetsFileInstance to, AssetsFileInstance from, long shaderPathID)
        {
            var toMats = to.file.GetAssetsOfType(AssetClassID.Material);
            var fromMats = from.file.GetAssetsOfType(AssetClassID.Material);

            var toNewMats = toMats.Where(t => !fromMats.Select(f => manager.GetBaseField(from, f)["m_Name"].AsString).Contains(manager.GetBaseField(to, t)["m_Name"].AsString));
            foreach (var toNewMat in toNewMats)
            {
                var toNewMatBase = manager.GetBaseField(to, toNewMat);
                AssignShaderToMaterial(toNewMat, toNewMatBase, shaderPathID);
                var toTexsOfMat = toNewMatBase["m_SavedProperties"]["m_TexEnvs"]["Array"];

                foreach (var toTexOfMat in toTexsOfMat)
                {
                    long original = toTexOfMat["second"]["m_Texture"]["m_PathID"].AsLong;
                    if (original == 0)
                        continue;

                    string newTexName = GetGameMaterialProperty(toTexOfMat["first"].AsString);
                    if (newTexName != "")
                        toTexOfMat["first"].AsString = newTexName;
                }

                toNewMat.SetNewData(toNewMatBase);
            }

            SetAssetsFileInBundle(to.parentBundle, to);
        }

        private void AssignShaderToMaterial(AssetFileInfo mat, AssetTypeValueField matBase, long pathID)
        {
            matBase["m_Shader"]["m_PathID"].AsLong = pathID;
            mat.SetNewData(matBase);
        }

        private string GetGameMaterialProperty(string windowsProperty)
        {
            switch (windowsProperty)
            {
                case "_BumpMap":
                    return "_BumpTex";
                case "_DetailAlbedoMap":
                    return "_LayerTex";
                case "_DetailMask":
                    return "_LayerComplexTex";
                case "_DetailNormalMap":
                    return "_LayerBumpTex";
                case "_EmissionMap":
                    return "_EmissionTex";
                case "_MainTex":
                    return "_MainTex";
                case "_MetallicGlossMap":
                    return "_MirrorMap";
                case "_OcclusionMap":
                    return "_BlendTex";
                case "_ParallaxMap": // Unsure on this one, just giving it the last one
                    return "_ComplexTex";
                default:
                    return "";
            }
        }

        private void ClearDependencies(AssetsFileInstance assetsFile)
        {
            assetsFile.file.Metadata.Externals.Clear();
        }

        private void AddDependency(AssetsFileInstance assetsFile, string path)
        {
            var deps = assetsFile.file.Metadata.Externals;
            AssetsFileExternal dep = new AssetsFileExternal()
            {
                VirtualAssetPathName = "",
                PathName = path,
                OriginalPathName = "",
                Type = AssetsFileExternalType.Normal,
                Guid = default,
            };
            deps.Add(dep);
        }

        private void CopyMaterial(AssetFileInfo toMat, AssetTypeValueField fromMatBase)
        {
            byte[] fromData = fromMatBase.WriteToByteArray();
            toMat.SetNewData(fromData);
        }

        private TypeTreeType ConvertTemplateFieldToTypeTree(ClassDatabaseFile cldbFile, AssetTypeTemplateField templateField, int typeId, ushort scriptIndex)
        {
            return typeTreeConverter.ConvertInternal(cldbFile, templateField, typeId, scriptIndex);
        }
    }
}
