namespace OdinEye.Http
{
    using Api.Controllers;
    using Logging;
    using ProtoBuf;
    using System.Collections.Generic;
    using System.IO;
    using WebSockets;
    using WebSocketSharp.Server;

    public class HttpWebServer
    {
        private const string DefaultWebSocketPath = "/activity";
        private readonly HttpServer httpServer;
        private WebSocketSessionManager defaultWebSocketSessionManager;
        
        private IEnumerable<IController> controllers = new IController[]
        {
            new PlayersController(),
            new ServerDetailsController(),
            new WorldDetailsController(),
            new BossDetailsController()
        };
        
        public HttpWebServer(string address, ILogger logger)
        {
            logger.LogInfo($"Starting Http Server at {address}");

            httpServer = new HttpServer(address);
            ConfigureHttpApi(); // maybe move this to a later stage like OnGameWorldLoaded
            ConfigureWebSocketServices();
            httpServer.Start();
        }

        private void ConfigureHttpApi()
        {
            httpServer.OnGet += (sender, args) =>
            {
                foreach (var controller in controllers)
                {
                    if (string.Equals(controller.Route, args.Request.RawUrl))
                    {
                        controller.OnGet(args);
                        break;
                    }
                }
            };
        }
        
        private void ConfigureWebSocketServices()
        {
            httpServer.AddWebSocketService<ActivityWebSocketService>(DefaultWebSocketPath);
            httpServer.KeepClean = true;
            defaultWebSocketSessionManager = httpServer.WebSocketServices[DefaultWebSocketPath].Sessions;
        }

        public void BroadcastWebSocketMessage<TInstance>(TInstance instance)
        {
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, instance);
                stream.Seek(0, SeekOrigin.Begin);
                defaultWebSocketSessionManager.Broadcast(stream, (int)stream.Length);
            }
        }
    }
}