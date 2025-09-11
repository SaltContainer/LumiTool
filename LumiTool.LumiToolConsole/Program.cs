using CommandLine;
using LumiTool.Runners;

namespace LumiTool
{
    class Program
    {
        private static Runner runner;

        static void Main(string[] args)
        {
            runner = new Runner();
            runner.CheckForSettings();

            Parser.Default.ParseArguments(args, runner.GetAllOptions())
                .WithParsed(runner.Run)
                .WithNotParsed(runner.HandleErrors);
        }
    }
}