using AssetsTools.NET;
using AssetsTools.NET.Extra;
using LumiTool.Data;

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

            to.parentBundle.file.BlockAndDirInfo.DirectoryInfos[0].SetNewData(to.file);
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
