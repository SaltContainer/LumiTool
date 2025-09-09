using AssetsTools.NET;
using CommandLine;

namespace LumiTool.Options
{
    [Verb("settings", HelpText = "Set global settings for LumiTool. These settings are separate from the ones used by the WinForms LumiTool app.")]
    public class SettingsOptions
    {
        [Option('d', "dependency-config", HelpText = "Path to the Dependency Remapping Configuration JSON file.", Required = false)]
        public string DependencyConfigPath { get; set; }

        [Option('c', "compression", HelpText = "Type of compression to use when saving Unity Asset Bundles.", Required = true)]
        public AssetBundleCompressionType AssetBundleCompressionMode { get; set; }
    }
}
