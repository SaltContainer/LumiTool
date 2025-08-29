using SmartPoint.AssetAssistant;

namespace LumiTool.Engine
{
    public class ManifestEngine
    {
        private LumiToolEngine engine;

        public AssetBundleDownloadManifest loadedManifest = null;

        public ManifestEngine(LumiToolEngine engine)
        {
            this.engine = engine;
        }

        public AssetBundleDownloadManifest GetLoadedManifest()
        {
            return loadedManifest;
        }

        public AssetBundleDownloadManifest LoadManifest(string path)
        {
            loadedManifest = AssetBundleDownloadManifest.Load(path);
            return loadedManifest;
        }

        public void SaveManifest(AssetBundleDownloadManifest manifest, string path)
        {
            manifest.Save(path, true);
        }

        public void ReplaceAllRecordsOfManifest(AssetBundleDownloadManifest manifest, AssetBundleRecord[] newRecords)
        {
            manifest.ReplaceAllRecords(newRecords);
        }

        public void RefreshManifest(AssetBundleDownloadManifest manifest, string romfsPath, string romfsVPath)
        {
            foreach (var record in manifest.records)
            {
                string path = Path.Combine(romfsPath, record.projectName, record.assetBundleName);
                string pathV = Path.Combine(romfsVPath, record.projectName, record.assetBundleName);
                record.size = engine.GetFileSizeAtPath(path) ?? engine.GetFileSizeAtPath(pathV) ?? -1;
            }

            manifest.RemoveRecordsWhere(r => r.size == -1);
        }

        public List<AssetBundleRecord> FindUnusedRecords(AssetBundleDownloadManifest manifest, string romfsPath, string romfsVPath)
        {
            var unusedRecords = new List<AssetBundleRecord>();

            foreach (var record in manifest.records)
            {
                string path = Path.Combine(romfsPath, record.projectName, record.assetBundleName);
                string pathV = Path.Combine(romfsVPath, record.projectName, record.assetBundleName);

                if (!engine.DoesFileExist(path) && !engine.DoesFileExist(pathV))
                    unusedRecords.Add(record);
            }

            return unusedRecords;
        }

        public List<string> GenerateLogOfUnusedRecords(AssetBundleDownloadManifest manifest, string romfsPath, string romfsVPath)
        {
            var unusedRecords = FindUnusedRecords(manifest, romfsPath, romfsVPath);
            return unusedRecords.Select(r => $"{r.projectName} - {r.assetBundleName}").ToList();
        }
    }
}
