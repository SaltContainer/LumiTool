using AssetsTools.NET.Extra;
using AssetsTools.NET;
using LumiTool.Data;
using LumiTool.Forms.Popups;

namespace LumiTool.Engine
{
    public class BundleEngine
    {
        private LumiToolEngine engine;

        private AssetsManager manager;
        private AssetsManager managerV;
        private TemplateFieldToTypeTree typeTreeConverter;

        public BundleEngine(LumiToolEngine engine)
        {
            this.engine = engine;

            manager = new AssetsManager();
            managerV = new AssetsManager();
            typeTreeConverter = new TemplateFieldToTypeTree();
        }

        public void UnloadBundles()
        {
            manager.UnloadAll();
            managerV.UnloadAll();
        }

        public BundleFileInstance LoadBundleFile(string path, ManagerID managerID)
        {
            return managerID switch
            {
                ManagerID.Modded => manager.LoadBundleFile(path, true),
                ManagerID.Vanilla => managerV.LoadBundleFile(path, true),
                _ => null,
            };
        }

        public AssetsFileInstance LoadAssetsFileFromBundle(BundleFileInstance bundle, ManagerID managerID)
        {
            return managerID switch
            {
                ManagerID.Modded => manager.LoadAssetsFileFromBundle(bundle, 0, false),
                ManagerID.Vanilla => managerV.LoadAssetsFileFromBundle(bundle, 0, false),
                _ => null,
            };
        }

        public void SetPlatformOfBundle(BundleFileInstance bundle, AssetsFileInstance assetsFile, Platform platform)
        {
            assetsFile.file.Metadata.TargetPlatform = Convert.ToUInt32(platform);
            SetAssetsFileInBundle(bundle, assetsFile);
        }

        public void SaveBundleToFile(BundleFileInstance bundle, string path)
        {
            using AssetsFileWriter writer = new AssetsFileWriter(path);
            bundle.file.Write(writer);
        }

        public ClassDatabaseFile LoadClassPackage(AssetsFileInstance assetsFile, ManagerID managerID)
        {
            switch (managerID)
            {
                case ManagerID.Modded:
                    manager.LoadClassPackage("classdata.tpk");
                    return manager.LoadClassDatabaseFromPackage(assetsFile.file.Metadata.UnityVersion);

                case ManagerID.Vanilla:
                    managerV.LoadClassPackage("classdata.tpk");
                    return managerV.LoadClassDatabaseFromPackage(assetsFile.file.Metadata.UnityVersion);

                default:
                    return null;
            }
        }

        public bool AddMonoScript(BundleFileInstance bundle, AssetsFileInstance assetsFile, string assembly, string namezpace, string klass, ManagerID managerID)
        {
            AssetsFile file = assetsFile.file;
            var cldb = LoadClassPackage(assetsFile, managerID);

            AssetsManager managerToUse;
            switch (managerID)
            {
                case ManagerID.Modded:
                    managerToUse = manager;
                    break;

                case ManagerID.Vanilla:
                    managerToUse = managerV;
                    break;

                default:
                    return false;
            }

            Random rand = new Random();
            var monoScriptPathId = rand.NextInt64();

            var monoScriptClassId = (int)AssetClassID.MonoScript;
            var monoScriptInfo = AssetFileInfo.Create(file, monoScriptPathId, monoScriptClassId, cldb);
            file.Metadata.AssetInfos.Add(monoScriptInfo);

            var monoScriptTemp = managerToUse.GetTemplateBaseField(assetsFile, monoScriptInfo);
            var monoScriptBf = ValueBuilder.DefaultValueFieldFromTemplate(monoScriptTemp);
            monoScriptBf["m_Name"].AsString = klass;
            monoScriptBf["m_ClassName"].AsString = klass;
            monoScriptBf["m_Namespace"].AsString = namezpace;
            monoScriptBf["m_AssemblyName"].AsString = assembly;

            monoScriptInfo.SetNewData(monoScriptBf);

            var newScriptId = file.Metadata.ScriptTypes.Count;

            file.Metadata.ScriptTypes.Add(new AssetPPtr(0, monoScriptPathId));

            var monoBehaviourClassId = (int)AssetClassID.MonoBehaviour;
            var monoBehaviourTemp = managerToUse.GetTemplateBaseField(assetsFile, null, 0, monoBehaviourClassId, (ushort)newScriptId, AssetReadFlags.SkipMonoBehaviourFields);

            managerToUse.MonoTempGenerator = new MonoCecilTempGenerator("Managed");
            var newBaseField = managerToUse.MonoTempGenerator.GetTemplateField(monoBehaviourTemp, assembly, namezpace, klass, new UnityVersion(file.Metadata.UnityVersion));

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

        public void CopyDependencies(AssetsFileInstance to, AssetsFileInstance from)
        {
            ClearDependencies(to);
            foreach (var dep in from.file.Metadata.Externals)
                to.file.Metadata.Externals.Add(dep);

            SetAssetsFileInBundle(to.parentBundle, to);
        }

        public void FixShadersOfMaterials(BundleFileInstance bundle, AssetsFileInstance assetsFile)
        {
            var mats = assetsFile.file.GetAssetsOfType(AssetClassID.Material);
            int shaderFileID = GetDependencyIndexOfShadersBundles(assetsFile);

            Dictionary<long, Shader> foundShaders = new Dictionary<long, Shader>();

            foreach (var mat in mats)
            {
                var matBase = manager.GetBaseField(assetsFile, mat);
                long currentShaderPathID = matBase["m_Shader"]["m_PathID"].AsLong;

                if (foundShaders.TryGetValue(currentShaderPathID, out Shader shader))
                {
                    AssignShaderToMaterial(mat, matBase, shaderFileID, shader.PathID);
                }
                else
                {
                    using FormShaderSelect shaderSelect = new FormShaderSelect(matBase["m_Name"].AsString, LumiToolEngine.ShaderList);
                    while (shaderSelect.ShowDialog() != DialogResult.OK)
                        MessageBox.Show("You must specify the shader used for this material!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    foundShaders.Add(currentShaderPathID, shaderSelect.Result);
                    AssignShaderToMaterial(mat, matBase, shaderFileID, shaderSelect.Result.PathID);
                }

                mat.SetNewData(matBase);
            }

            SetAssetsFileInBundle(bundle, assetsFile);
        }

        public void AddDependency(AssetsFileInstance assetsFile, string path)
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

        public void CopyMaterial(AssetFileInfo toMat, AssetTypeValueField fromMatBase)
        {
            byte[] fromData = fromMatBase.WriteToByteArray();
            toMat.SetNewData(fromData);
        }

        public bool ChangeShadersBundlePathIDs(BundleFileInstance toBundle, AssetsFileInstance toAssetsFile, BundleFileInstance fromBundle, AssetsFileInstance fromAssetsFile)
        {
            bool allChanged = true;

            var shaders = toAssetsFile.file.GetAssetsOfType(AssetClassID.Shader);
            var shadersV = fromAssetsFile.file.GetAssetsOfType(AssetClassID.Shader);
            var shadersBaseV = shadersV.Select(s => managerV.GetBaseField(fromAssetsFile, s)).ToList();

            foreach (var shader in shaders)
            {
                var shaderBase = manager.GetBaseField(toAssetsFile, shader);
                var shaderIndex = FindShaderOfName(shadersBaseV, shaderBase["m_ParsedForm"]["m_Name"].AsString);
                if (shaderIndex < 0)
                {
                    allChanged = false;
                    continue;
                }

                long newPathId = shadersV[shaderIndex].PathId;
                shader.SetRemoved();

                var newShaderInfo = AssetFileInfo.Create(toAssetsFile.file, newPathId, (int)AssetClassID.Shader, null);
                newShaderInfo.SetNewData(shaderBase);
                toAssetsFile.file.Metadata.AddAssetInfo(newShaderInfo);
            }

            var mats = toAssetsFile.file.GetAssetsOfType(AssetClassID.Material);
            var matsV = fromAssetsFile.file.GetAssetsOfType(AssetClassID.Material);
            var matsBaseV = matsV.Select(m => managerV.GetBaseField(fromAssetsFile, m)).ToList();

            foreach (var mat in mats)
            {
                var matBase = manager.GetBaseField(toAssetsFile, mat);
                var matIndex = FindObjectOfName(matsBaseV, matBase["m_Name"].AsString);
                if (matIndex < 0)
                {
                    allChanged = false;
                    continue;
                }

                long newPathId = matsV[matIndex].PathId;
                mat.SetRemoved();

                var newMatInfo = AssetFileInfo.Create(toAssetsFile.file, newPathId, (int)AssetClassID.Material, null);
                newMatInfo.SetNewData(matBase);
                toAssetsFile.file.Metadata.AddAssetInfo(newMatInfo);
            }

            var fromPreloadTable = managerV.GetBaseField(fromAssetsFile, fromAssetsFile.file.GetAssetInfo(1));
            toAssetsFile.file.GetAssetInfo(1).SetNewData(fromPreloadTable);

            SetAssetsFileInBundle(toBundle, toAssetsFile);
            return allChanged;
        }

        public void RenameBundle(BundleFileInstance bundle, AssetsFileInstance assetsFile, string newName, string newCAB)
        {
            string oldCAB = assetsFile.name;
            assetsFile.name = newCAB;
            foreach (AssetBundleDirectoryInfo dirInfo in bundle.file.BlockAndDirInfo.DirectoryInfos)
                dirInfo.Name = dirInfo.Name.Replace(oldCAB, newCAB);

            var preloadTable = manager.GetBaseField(assetsFile, assetsFile.file.GetAssetInfo(1));
            preloadTable["m_Name"].AsString = newName;
            preloadTable["m_AssetBundleName"].AsString = newName;
            assetsFile.file.GetAssetInfo(1).SetNewData(preloadTable);

            SetAssetsFileInBundle(bundle, assetsFile);
        }

        private int GetDependencyIndexOfShadersBundles(AssetsFileInstance assetsFile)
        {
            return assetsFile.file.Metadata.Externals.FindIndex(d => d.PathName == "archive:/CAB-1dc8d26be8722a766953ce9d8a444e8c/CAB-1dc8d26be8722a766953ce9d8a444e8c") + 1;
        }

        private void AssignShaderToMaterial(AssetFileInfo mat, AssetTypeValueField matBase, long fileID, long pathID)
        {
            if (fileID != -1)
                matBase["m_Shader"]["m_FileID"].AsLong = fileID;

            matBase["m_Shader"]["m_PathID"].AsLong = pathID;

            mat.SetNewData(matBase);
        }

        private void ClearDependencies(AssetsFileInstance assetsFile)
        {
            assetsFile.file.Metadata.Externals.Clear();
        }

        private TypeTreeType ConvertTemplateFieldToTypeTree(ClassDatabaseFile cldbFile, AssetTypeTemplateField templateField, int typeId, ushort scriptIndex)
        {
            return typeTreeConverter.ConvertInternal(cldbFile, templateField, typeId, scriptIndex);
        }

        private void SetAssetsFileInBundle(BundleFileInstance bundle, AssetsFileInstance assetsFile)
        {
            bundle.file.BlockAndDirInfo.DirectoryInfos[0].SetNewData(assetsFile.file);
        }

        private int FindShaderOfName(List<AssetTypeValueField> shaderBaseFields, string name)
        {
            return shaderBaseFields.FindIndex(s => s["m_ParsedForm"]["m_Name"].AsString == name);
        }

        private int FindObjectOfName(List<AssetTypeValueField> objBaseFields, string name)
        {
            return objBaseFields.FindIndex(s => s["m_Name"].AsString == name);
        }

        public enum ManagerID
        {
            Modded,
            Vanilla,
        }
    }
}
