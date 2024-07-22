using SmartPoint.AssetAssistant;

namespace LumiTool.Engine
{
    public class ManifestEngine
    {
        public AssetBundleDownloadManifest loadedManifest = null;

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
    }
}
