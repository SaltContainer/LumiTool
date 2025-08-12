using LumiTool.Engine;
using LumiTool.Utils;

namespace LumiTool
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Disable command prompt stuff for now
            /*var args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                // There are arguments, run as command line program with no GUI
                ConsoleRegisterer.RegisterNewConsole();

                var engine = new LumiToolEngine();
                engine.RunAsCommandLine(args);

                ConsoleRegisterer.UnregisterConsole();
            }
            else
            {
                // No extra arguments, run as the regular app with GUI

                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.Run(new FormMain());
            }*/


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.Run(new FormMain());
        }
    }
}