using CommandLine;
using LumiTool.Data;
using LumiTool.Data.Options;

namespace LumiTool.Engine
{
    public class CommandLineEngine
    {
        private LumiToolEngine engine;

        private Parser parser;

        public CommandLineEngine(LumiToolEngine engine)
        {
            this.engine = engine;

            parser = new Parser(config => config.HelpWriter = Console.Out);
        }

        public bool ParseCommandLineArguments(string[] args)
        {
            var parseResult = parser.ParseArguments<
                ChangePlatformOptions
                >(args);

            var result = parseResult
                /*.WithNotParsed(x => Console.WriteLine(
                    HelpText.AutoBuild(parseResult,
                        h => HelpText.DefaultParsingErrorsHandler(parseResult, h),
                        e => e)
                    )
                )*/
                .MapResult(
                    (ChangePlatformOptions opts) => RunChangePlatform(opts),
                    /*errs =>
                    {
                        foreach (var err in errs)
                            Console.WriteLine(err.ToString());

                        return CommandLineResult.OtherError;
                    }*/
                    errs => CommandLineResult.OtherError
                );

            return result == CommandLineResult.Success;
        }

        public CommandLineResult RunChangePlatform(ChangePlatformOptions opts)
        {
            var inputPath = opts.InputPath;
            var outPath = opts.OutputPath;
            var platform = opts.Platform;

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("[Argument -i --input] File \"{0}\" not found.", inputPath);
                return CommandLineResult.FileNotFound;
            }

            if (File.Exists(outPath))
            {
                Console.WriteLine("[Argument -o --output] File \"{0}\" already exists.", outPath);
                return CommandLineResult.FileExists;
            }

            if (!Directory.Exists(Path.GetDirectoryName(outPath)))
            {
                Console.WriteLine("[Argument -o --output] Directory \"{0}\" not found.", Path.GetDirectoryName(outPath));
                return CommandLineResult.DirectoryNotFound;
            }

            var bundle = engine.LoadBundle(inputPath, BundleEngine.ManagerID.Modded);
            var afileInst = engine.LoadAssetsFileFromBundle(bundle, BundleEngine.ManagerID.Modded);
            engine.SetPlatformOfBundle(bundle, afileInst, platform);
            engine.SaveBundleToFile(bundle, outPath);

            Console.WriteLine("Changed the platform of \"{0}\" to {1} and saved it to \"{2}\".", inputPath, platform, outPath);

            return CommandLineResult.Success;
        }
    }
}
