using System.Runtime.InteropServices;

namespace LumiTool.Utils
{
    public class ConsoleRegisterer
    {
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();

        private const int ATTACH_PARENT_PROCESS = -1;

        private static bool attachedToConsole = false;

        public static bool RegisterConsole()
        {
            attachedToConsole = AttachConsole(ATTACH_PARENT_PROCESS);

            if (!attachedToConsole)
                AllocConsole();

            return attachedToConsole;
        }

        public static bool RegisterNewConsole()
        {
            return AllocConsole();
        }

        public static bool UnregisterConsole()
        {
            bool freed = FreeConsole();

            if (attachedToConsole)
                SendKeys.SendWait("{ENTER}");

            return freed;
        }
    }
}
