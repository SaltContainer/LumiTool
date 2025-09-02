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

        public void ReassignExternalDependencyReferences(BundleFileInstance bundle, AssetsFileInstance assetsFile, bool showBundleNameInPopup, List<string> selectedCabs)
        {
            ReassignExternalDependencyReferences(bundle, assetsFile, showBundleNameInPopup, new Dictionary<(string, long), DependencyAsset>(), selectedCabs);
        }

        public void ReassignExternalDependencyReferences(BundleFileInstance bundle, AssetsFileInstance assetsFile, bool showBundleNameInPopup, Dictionary<(string, long), DependencyAsset> foundReferences, List<string> selectedCabs)
        {
            var assets = assetsFile.file.AssetInfos.Where(a => a.PathId != 1);
            assets = assets.Append(assetsFile.file.GetAssetInfo(1));

            var fileIDToCAB = GetFileIDToCABNameDict(assetsFile);

            foreach (var asset in assets)
            {
                var assetBase = manager.GetBaseField(assetsFile, asset);
                CheckFieldForExternalDependency(assetsFile, assetBase, assetBase, fileIDToCAB, showBundleNameInPopup, foundReferences, selectedCabs, bundle.name, "");
                asset.SetNewData(assetBase);
            }

            SetAssetsFileInBundle(bundle, assetsFile);
        }

        public List<string> GetCABNamesInBundleDependencies(AssetsFileInstance assetsFile)
        {
            var cabNames = new List<string>();

            foreach (var external in assetsFile.file.Metadata.Externals)
            {
                var externalNameParts = external.PathName.Split('/');
                if (externalNameParts.Length >= 2)
                    cabNames.Add(externalNameParts[1]);
            }

            return cabNames;
        }

        private Dictionary<int, string> GetFileIDToCABNameDict(AssetsFileInstance assetsFile)
        {
            var fileIDToCAB = new Dictionary<int, string>();
            for (int i=0; i<assetsFile.file.Metadata.Externals.Count; i++)
            {
                var external = assetsFile.file.Metadata.Externals[i];
                var externalNameParts = external.PathName.Split('/');
                if (externalNameParts.Length >= 2)
                    fileIDToCAB.Add(i + 1, externalNameParts[1]);
            }

            var notFoundCabs = new List<string>();
            foreach (var cab in fileIDToCAB.Values)
            {
                if (engine.GetDependencyConfig()[cab] == null)
                    notFoundCabs.Add(cab);
            }

            if (notFoundCabs.Any())
                MessageBox.Show($"The current dependency config does not contain data for the bundles with the following CAB names:\n{string.Join("\n", notFoundCabs)}\n\nAssets with a reference to these dependencies will not be changed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return fileIDToCAB;
        }

        private string FormatArchiveCABName(string cabName)
        {
            return $"archive:/{cabName}/{cabName}";
        }

        private void AssignShaderToMaterial(AssetFileInfo mat, AssetTypeValueField matBase, int fileID, long pathID)
        {
            RemapReference(matBase["m_Shader"], fileID, pathID);
            mat.SetNewData(matBase);
        }

        private void RemapReference(AssetTypeValueField field, int fileID, long pathID)
        {
            if (fileID != -1)
                field["m_FileID"].AsInt = fileID;

            field["m_PathID"].AsLong = pathID;
        }

        private void UpdateReferencesInPreloadTable(AssetTypeValueField preloadTable, Dictionary<(int, long), (int, long)> updates)
        {
            var assets = preloadTable["m_PreloadTable"]["Array"];
            foreach (var asset in assets)
            {
                if (updates.TryGetValue((asset["m_FileID"].AsInt, asset["m_PathID"].AsLong), out (int newFileID, long newPathID) newValues))
                {
                    asset["m_FileID"].AsInt = newValues.newFileID;
                    asset["m_PathID"].AsLong = newValues.newPathID;
                }
            }
        }

        private void CheckFieldForExternalDependency(AssetsFileInstance assetsFile, AssetTypeValueField baseField, AssetTypeValueField currentField, Dictionary<int, string> fileIDToCAB, bool showBundleNameInPopup, Dictionary<(string, long), DependencyAsset> foundReferences, List<string> selectedCabs, string bundleName, string fieldPath)
        {
            if (currentField.TypeName.StartsWith("PPtr<") && currentField.TypeName.EndsWith(">"))
            {
                int currentFileID = currentField["m_FileID"].AsInt;
                long currentPathID = currentField["m_PathID"].AsLong;

                string currentTypeName = currentField.TypeName[5..^1].TrimStart('$');

                // Not an external reference
                if (currentFileID == 0)
                    return;

                // Not one of our selected CABs
                if (!selectedCabs.Contains(fileIDToCAB[currentFileID]))
                    return;

                if (foundReferences.TryGetValue((fileIDToCAB[currentFileID], currentPathID), out DependencyAsset dependencyAsset))
                {
                    RemapReference(currentField, currentFileID, dependencyAsset.PathID);
                }
                else
                {
                    var dependencyAssets = engine.GetDependencyConfig()[fileIDToCAB[currentFileID]];

                    // Not in settings, so ignored
                    if (dependencyAssets == null)
                        return;

                    string assetName = GenerateNameOfAsset(assetsFile, baseField);

                    using FormDependencyAssetSelect assetSelect = showBundleNameInPopup ?
                        new FormDependencyAssetSelect(assetName, $"{fieldPath}/{currentField.FieldName}", bundleName, dependencyAssets.Where(a => a.Type.ToString() == currentTypeName).ToList()) :
                        new FormDependencyAssetSelect(assetName, $"{fieldPath}/{currentField.FieldName}", dependencyAssets.Where(a => a.Type.ToString() == currentTypeName).ToList());
                    while (assetSelect.ShowDialog() != DialogResult.OK)
                        MessageBox.Show("You must specify what this asset references!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    foundReferences.Add((fileIDToCAB[currentFileID], currentPathID), assetSelect.Result);
                    RemapReference(currentField, currentFileID, assetSelect.Result.PathID);
                }
            }
            else if (currentField.Value == null)
            {
                foreach (var subField in currentField)
                {
                    CheckFieldForExternalDependency(assetsFile, baseField, subField, fileIDToCAB, showBundleNameInPopup, foundReferences, selectedCabs, bundleName, $"{fieldPath}/{currentField.FieldName}");
                }
            }
            else if (currentField.Value.ValueType == AssetValueType.Array)
            {
                foreach (var (subField, i) in currentField.Select((e, i) => (e, i)))
                {
                    CheckFieldForExternalDependency(assetsFile, baseField, subField, fileIDToCAB, showBundleNameInPopup, foundReferences, selectedCabs, bundleName, $"{fieldPath}/{currentField.FieldName}/{i}");
                }
            }
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

        private string GenerateNameOfAsset(AssetsFileInstance assetsFile, AssetTypeValueField baseField)
        {
            if (!baseField["m_Name"].IsDummy && baseField.TypeName == AssetClassID.MonoBehaviour.ToString() && !baseField["m_Script"].IsDummy && !baseField["m_GameObject"].IsDummy)
                return $"{manager.GetBaseField(assetsFile, manager.GetExtAsset(assetsFile, baseField["m_Script"]).info)["m_ClassName"].AsString} \"{baseField["m_Name"].AsString}\" of GameObject \"{manager.GetBaseField(assetsFile, manager.GetExtAsset(assetsFile, baseField["m_GameObject"]).info)["m_Name"].AsString}\"";
            else if (!baseField["m_Name"].IsDummy)
                return $"{baseField.TypeName} \"{baseField["m_Name"].AsString}\"";
            else if (!baseField["m_GameObject"].IsDummy)
                return $"{baseField.TypeName} \"{manager.GetBaseField(assetsFile, manager.GetExtAsset(assetsFile, baseField["m_GameObject"]).info)["m_Name"].AsString}\"";
            else
                return "--Unknown name--";
        }

        public enum ManagerID
        {
            Modded,
            Vanilla,
        }
    }
}
