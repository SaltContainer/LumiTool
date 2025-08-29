using AssetsTools.NET;
using AssetsTools.NET.Extra;
using LumiTool.Data;
using LumiTool.Data.Wwise;
using SmartPoint.AssetAssistant;

namespace LumiTool.Engine
{
    public class LumiToolEngine
    {
        private BundleEngine bundleEngine;
        private ManifestEngine manifestEngine;
        private FileSystemEngine fileSystemEngine;
        private WwiseEngine wwiseEngine;
        private CommandLineEngine commandLineEngine;
        private ConfigEngine configEngine;

        public LumiToolEngine()
        {
            bundleEngine = new BundleEngine(this);
            manifestEngine = new ManifestEngine(this);
            fileSystemEngine = new FileSystemEngine(this);
            wwiseEngine = new WwiseEngine(this);
            commandLineEngine = new CommandLineEngine(this);
            configEngine = new ConfigEngine(this);
        }

        public void UnloadBundles()
        {
            bundleEngine.UnloadBundles();
        }

        public BundleFileInstance LoadBundle(string path, BundleEngine.ManagerID managerID)
        {
            return bundleEngine.LoadBundleFile(path, managerID);
        }

        public AssetsFileInstance LoadAssetsFileFromBundle(BundleFileInstance bundle, BundleEngine.ManagerID managerID)
        {
            return bundleEngine.LoadAssetsFileFromBundle(bundle, managerID);
        }

        public void SetPlatformOfBundle(BundleFileInstance bundle, AssetsFileInstance assetsFile, Platform platform)
        {
            bundleEngine.SetPlatformOfBundle(bundle, assetsFile, platform);
        }

        public void SaveBundleToFile(BundleFileInstance bundle, string path)
        {
            bundleEngine.SaveBundleToFile(bundle, path);
        }

        public ClassDatabaseFile LoadClassPackage(AssetsFileInstance assetsFile, BundleEngine.ManagerID managerID)
        {
            return bundleEngine.LoadClassPackage(assetsFile, managerID);
        }

        public bool AddMonoScript(BundleFileInstance bundle, AssetsFileInstance assetsFile, string assembly, string namezpace, string klass, BundleEngine.ManagerID managerID)
        {
            return bundleEngine.AddMonoScript(bundle, assetsFile, assembly, namezpace, klass, managerID);
        }

        public void CopyDependencies(AssetsFileInstance to, AssetsFileInstance from)
        {
            bundleEngine.CopyDependencies(to, from);
        }

        public void FixShadersOfMaterials(BundleFileInstance bundle, AssetsFileInstance assetsFile, bool showBundleNameInPopup = false)
        {
            bundleEngine.FixShadersOfMaterials(bundle, assetsFile, showBundleNameInPopup);
        }

        public void FixShadersOfMaterials(BundleFileInstance bundle, AssetsFileInstance assetsFile, bool showBundleNameInPopup, Dictionary<(string, long), Shader> foundShaders)
        {
            bundleEngine.FixShadersOfMaterials(bundle, assetsFile, showBundleNameInPopup, foundShaders);
        }

        public void AddDependency(AssetsFileInstance assetsFile, string path)
        {
            bundleEngine.AddDependency(assetsFile, path);
        }

        public void CopyMaterial(AssetFileInfo toMat, AssetTypeValueField fromMatBase)
        {
            bundleEngine.CopyMaterial(toMat, fromMatBase);
        }

        public AssetBundleDownloadManifest LoadManifest(string path)
        {
            return manifestEngine.LoadManifest(path);
        }

        public void SaveManifest(AssetBundleDownloadManifest manifest, string path)
        {
            manifestEngine.SaveManifest(manifest, path);
        }

        public void ReplaceAllRecordsOfManifest(AssetBundleDownloadManifest manifest, AssetBundleRecord[] newRecords)
        {
            manifestEngine.ReplaceAllRecordsOfManifest(manifest, newRecords);
        }

        public void RefreshManifest(AssetBundleDownloadManifest manifest, string romfsPath, string romfsVPath)
        {
            manifestEngine.RefreshManifest(manifest, romfsPath, romfsVPath);
        }

        public List<AssetBundleRecord> FindUnusedRecords(AssetBundleDownloadManifest manifest, string romfsPath, string romfsVPath)
        {
            return manifestEngine.FindUnusedRecords(manifest, romfsPath, romfsVPath);
        }

        public List<string> GenerateLogOfUnusedRecords(AssetBundleDownloadManifest manifest, string romfsPath, string romfsVPath)
        {
            return manifestEngine.GenerateLogOfUnusedRecords(manifest, romfsPath, romfsVPath);
        }

        public string? FindAssetAssistantPath(string path)
        {
            return fileSystemEngine.FindAssetAssistantPath(path);
        }

        public bool ChangeShadersBundlePathIDs(BundleFileInstance toBundle, AssetsFileInstance toAssetsFile, BundleFileInstance fromBundle, AssetsFileInstance fromAssetsFile)
        {
            return bundleEngine.ChangeShadersBundlePathIDs(toBundle, toAssetsFile, fromBundle, fromAssetsFile);
        }

        public long? GetFileSizeAtPath(string path)
        {
            return fileSystemEngine.GetFileSizeAtPath(path);
        }

        public bool DoesFileExist(string path)
        {
            return fileSystemEngine.DoesFileExist(path);
        }

        public void RenameBundle(BundleFileInstance bundle, AssetsFileInstance assetsFile, string newName, string newCAB)
        {
            bundleEngine.RenameBundle(bundle, assetsFile, newName, newCAB);
        }

        public WwiseData LoadBank(string path)
        {
            return wwiseEngine.LoadBank(path);
        }

        public void SaveBank(WwiseData wd, string path)
        {
            wwiseEngine.SaveBank(wd, path);
        }

        public void CloneHircEvent(WwiseData wd, string oldEventName, string newEventName, string groupName, bool loopEdit = false, double initDelay = 0, double loopStart = 0, double loopEnd = 0, double totalDuration = 0)
        {
            wwiseEngine.CloneHircEvent(wd, oldEventName, newEventName, groupName, loopEdit, initDelay, loopStart, loopEnd, totalDuration);
        }

        public List<Event> GetEventsOfBank(WwiseData wd)
        {
            return wwiseEngine.GetEventsOfBank(wd);
        }

        public List<Data.Wwise.Action> GetActionsOfEvent(WwiseData wd, Event ev)
        {
            return wwiseEngine.GetActionsOfEvent(wd, ev);
        }

        public uint FNV132Hash(string data)
        {
            return wwiseEngine.FNV132Hash(data);
        }

        public void RunAsCommandLine(string[] args)
        {
            commandLineEngine.ParseCommandLineArguments(args);
        }

        public bool UserConfigExists()
        {
            return configEngine.UserConfigExists();
        }

        public void SetFirstBootConfig()
        {
            configEngine.SetFirstBootConfig();
        }

        public void ReloadShaderConfig()
        {
            configEngine.ReloadShaderConfig();
        }

        public bool TryReloadShaderConfig()
        {
            return configEngine.TryReloadShaderConfig();
        }

        public ShaderConfig GetShaderConfig()
        {
            return configEngine.GetShaderConfig();
        }

        public string GetShaderConfigPath()
        {
            return configEngine.GetShaderConfigPath();
        }

        public bool SetShaderConfigPath(string newPath)
        {
            return configEngine.SetShaderConfigPath(newPath);
        }

        public bool IsShaderConfigLoaded()
        {
            return configEngine.IsShaderConfigLoaded();
        }

        public void ReloadDependencyConfig()
        {
            configEngine.ReloadDependencyConfig();
        }

        public bool TryReloadDependencyConfig()
        {
            return configEngine.TryReloadDependencyConfig();
        }

        public ShaderConfig GetDependencyConfig()
        {
            return configEngine.GetDependencyConfig();
        }

        public string GetDependencyConfigPath()
        {
            return configEngine.GetDependencyConfigPath();
        }

        public bool SetDependencyConfigPath(string newPath)
        {
            return configEngine.SetDependencyConfigPath(newPath);
        }

        public bool IsDependencyConfigLoaded()
        {
            return configEngine.IsDependencyConfigLoaded();
        }

        public void ReassignExternalDependencyReferences(BundleFileInstance bundle, AssetsFileInstance assetsFile, bool showBundleNameInPopup = false)
        {
            bundleEngine.ReassignExternalDependencyReferences(bundle, assetsFile, showBundleNameInPopup);
        }

        public void ReassignExternalDependencyReferences(BundleFileInstance bundle, AssetsFileInstance assetsFile, bool showBundleNameInPopup, Dictionary<(string, long), Shader> foundReferences)
        {
            bundleEngine.ReassignExternalDependencyReferences(bundle, assetsFile, showBundleNameInPopup, foundReferences);
        }
    }
}
