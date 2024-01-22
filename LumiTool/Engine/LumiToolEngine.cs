using AssetsTools.NET;
using AssetsTools.NET.Extra;
using LumiTool.Data;

namespace LumiTool.Engine
{
    public class LumiToolEngine
    {
        private AssetsManager manager;

        public LumiToolEngine()
        {
            manager = new AssetsManager();
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

        public void SetPlatformOfBundle(BundleFileInstance bundle, AssetsFileInstance assetsFile, Platform platform)
        {
            assetsFile.file.Metadata.TargetPlatform = Convert.ToUInt32(platform);
            bundle.file.BlockAndDirInfo.DirectoryInfos[0].SetNewData(assetsFile.file);
        }

        public void SaveBundleToFile(BundleFileInstance bundle, string path)
        {
            using (AssetsFileWriter writer = new AssetsFileWriter(path))
            {
                bundle.file.Write(writer);
            }
        }
    }
}
