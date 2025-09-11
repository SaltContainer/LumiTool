using LumiTool.Engine;
using LumiTool.Options;

namespace LumiTool.Runners
{
    public class ChangePlatformRunner
    {
        private LumiToolEngine engine;

        public ChangePlatformRunner(LumiToolEngine engine)
        {
            this.engine = engine;
        }

        public void Run(ChangePlatformOptions options)
        {
            try
            {
                var bundle = engine.LoadBundle(options.InputPath, BundleEngine.ManagerID.Modded);
                var afileInst = engine.LoadAssetsFileFromBundle(bundle, BundleEngine.ManagerID.Modded);
                engine.SetPlatformOfBundle(bundle, afileInst, options.Platform);
                engine.SaveBundleToFile(bundle, options.OutputPath);
                Console.WriteLine($"[Change Platform] Successfully changed the bundle's platform to \"{options.Platform}\"!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Change Platform] There was an exception when changing the platform of the bundle. Full Exception: {ex.Message}");
            }
        }
    }
}
