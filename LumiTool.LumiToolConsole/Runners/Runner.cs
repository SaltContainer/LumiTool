using CommandLine;
using LumiTool.Engine;
using LumiTool.Options;

namespace LumiTool.Runners
{
    public class Runner
    {
        private LumiToolEngine engine;

        private ChangePlatformRunner changePlatformRunner;
        private SettingsRunner settingsRunner;
        private BundlePrepperRunner bundlePrepperRunner;

        public Runner()
        {
            engine = new LumiToolEngine();

            changePlatformRunner = new ChangePlatformRunner(engine);
            settingsRunner = new SettingsRunner(engine);
            bundlePrepperRunner = new BundlePrepperRunner(engine);
        }

        public Type[] GetAllOptions()
        {
            return new Type[] {
                typeof(ChangePlatformOptions),
                typeof(SettingsOptions),
                typeof(BundlePrepperOptions),
            };
        }

        public void CheckForSettings()
        {
            if (!engine.UserConfigExists())
            {
                Console.WriteLine("[LumiTool] The user settings are not currently set. Some of the tools could have unexpected behavior.");
                Console.WriteLine("[LumiTool] You can set the settings using \"LumiTool.LumiToolConsole.exe settings\" with the appropriate options.");
            }
            else
            {
                engine.TryReloadDependencyConfig();
            }
        }

        public void Run(object options)
        {
            switch (options)
            {
                case ChangePlatformOptions cpo:
                    changePlatformRunner.Run(cpo);
                    break;
                case SettingsOptions so:
                    settingsRunner.Run(so);
                    break;
                case BundlePrepperOptions bpo:
                    bundlePrepperRunner.Run(bpo);
                    break;
            }
        }

        public void HandleErrors(IEnumerable<Error> errors)
        {
            // TODO
        }
    }
}
