using LumiTool.Data;

namespace LumiTool.Engine
{
    public class LoggerEngine
    {
        public delegate void LogDelegate(string message, LogLevel level);

        private LumiToolEngine engine;

        private event LogDelegate onlog;

        public LoggerEngine(LumiToolEngine engine)
        {
            this.engine = engine;
        }

        public void AddOnLogCallback(LogDelegate callback)
        {
            onlog += callback;
        }

        public void RemoveOnLogCallback(LogDelegate callback)
        {
            onlog -= callback;
        }

        public void Log(string message, LogLevel level)
        {
            onlog?.Invoke(message, level);
        }
    }
}
