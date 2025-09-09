using CommandLine;

namespace LumiTool.Options
{
    [Verb("bundle-prepper", HelpText = "Prepare a bundle for use in the game.")]
    public class BundlePrepperOptions
    {
        [Option('i', "input", HelpText = "Path to the bundle to edit.", Required = true)]
        public string InputPath { get; set; }

        [Option('o', "output", HelpText = "Path to save the bundle to.", Required = true)]
        public string OutputPath { get; set; }

        [Option('v', "input-vanilla", HelpText = "Path to the vanilla version of the bundle. Only required if the \"Copy Dependencies\" step is enabled.", Required = false)]
        public string VanillaPath { get; set; }

        [Option('t', "load-tpk", HelpText = "Enable reading the class package \"classdata.tpk\" for bundles with no type tree.", Required = false, Default = false)]
        public bool LoadClassData { get; set; }

        [Option('p', "set-platform", HelpText = "Enable the \"Change Platform to Switch\" step.", Required = false, Default = false)]
        public bool SetPlatform { get; set; }

        [Option('c', "copy-dependencies", HelpText = "Enable the \"Copy Dependencies\" step.", Required = false, Default = false)]
        public bool CopyDependencies { get; set; }

        [Option('r', "remap-dependencies", HelpText = "Enable the \"Remap References to Dependencies\" step.", Required = false, Default = false)]
        public bool RemapDependencies { get; set; }
    }
}
