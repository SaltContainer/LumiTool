using LumiTool.Engine;
using LumiTool.Options;

namespace LumiTool.Runners
{
    public class SettingsRunner
    {
        private LumiToolEngine engine;

        public SettingsRunner(LumiToolEngine engine)
        {
            this.engine = engine;
        }

        public void Run(SettingsOptions options)
        {
            if (options.DependencyConfigPath != null)
            {
                if (engine.SetDependencyConfigPath(options.DependencyConfigPath))
                    Console.WriteLine($"[Settings] Successfully set the dependency remapping configuration path to \"{engine.GetDependencyConfigPath()}\"!");
                else
                    Console.WriteLine($"[Settings] The dependency remapping configuration could not be loaded. The previous path of \"{engine.GetDependencyConfigPath()}\" will be restored.");
            }

            engine.SetAssetBundleCompressionType(options.AssetBundleCompressionMode);
            Console.WriteLine($"[Settings] Successfully set the asset bundle compression mode to \"{options.AssetBundleCompressionMode}\"!");

            engine.SetFirstBootConfig();
        }
    }
}
