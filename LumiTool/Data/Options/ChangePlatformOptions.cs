using CommandLine;

namespace LumiTool.Data.Options
{
    [Verb("change-platform", HelpText = "Change a bundle's platform metadata.")]
    public class ChangePlatformOptions
    {
        [Option('i', "input", HelpText = "Path to the bundle to edit.", Required = true)]
        public string InputPath { get; set; }

        [Option('o', "output", HelpText = "Path to save the bundle to.", Required = true)]
        public string OutputPath { get; set; }

        [Option('p', "platform", HelpText = "Platform to set the bundle to.", Required = true)]
        public Platform Platform { get; set; }
    }
}
