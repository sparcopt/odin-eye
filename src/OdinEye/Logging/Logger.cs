namespace OdinEye.Logging
{
    using BepInEx.Logging;

    public class Logger : ILogger
    {
        private readonly ManualLogSource manualLogSource;

        public Logger(ManualLogSource manualLogSource)
        {
            this.manualLogSource = manualLogSource;
        }

        public void LogFatal(object data) => manualLogSource.Log(LogLevel.Fatal, data);

        public void LogError(object data) => manualLogSource.Log(LogLevel.Error, data);

        public void LogWarning(object data) => manualLogSource.Log(LogLevel.Warning, data);

        public void LogMessage(object data) => manualLogSource.Log(LogLevel.Message, data);

        public void LogInfo(object data) => manualLogSource.Log(LogLevel.Info, data);

        public void LogDebug(object data) => manualLogSource.Log(LogLevel.Debug, data);
    }
}