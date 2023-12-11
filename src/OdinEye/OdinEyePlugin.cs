namespace OdinEye
{
    using BepInEx;
    using BepInEx.Configuration;
    using Coroutines;
    using Events;
    using HarmonyLib;
    using Http;
    using Logging;
    using Middlewares;
    using System.Reflection;

    [BepInPlugin("org.bepinex.plugins.odineye", "odineye", "1.0.0.0")]
    public class OdinEyePlugin : BaseUnityPlugin
    {
        private ConfigEntry<string> httpServerAddress;
        public static OdinEyePlugin Instance { get; private set; }
        public ILogger Logger { get; private set; }
        public EventHandler EventHandler { get; private set; }
        public HttpWebServer HttpWebServer { get; private set; }
        public GameStatsSnapshotCoroutine StatsSnapshotCoroutine { get; private set; }

        private void Awake()
        {
            Instance = this;
            Logger = new Logger(base.Logger);
            Logger.LogInfo("OdinEye starting!");

            LoadConfiguration();
            SetupDependencies();
            SetupHarmonyPatches();
            
            Logger.LogInfo("OdinEye running!");
        }

        private void LoadConfiguration() =>
            httpServerAddress = Config.Bind("Hosting", "HttpServerAddress", string.Empty, "The network address where the Http Server will be hosted");
        
        private void SetupHarmonyPatches()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var harmony = new Harmony("org.bepinex.plugins.odineye");
            harmony.PatchAll(assembly);
        }
        
        private void SetupDependencies()
        {
            HttpWebServer = new HttpWebServer(httpServerAddress.Value, Logger);
            StatsSnapshotCoroutine = new GameStatsSnapshotCoroutine(HttpWebServer);
            EventHandler = new EventHandler();
            EventHandler.Configure(options => options
                .AddMiddleware(new ExceptionHandlerMiddleware(Logger))
                .AddMiddleware(new LoggingMiddleware(Logger))
                .AddMiddleware(new EventDispatcherMiddleware(HttpWebServer)));
        }
    }
}