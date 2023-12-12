namespace OdinEye.Middlewares
{
    using Http;
    using Models.Proto;

    public class EventDispatcherMiddleware : EventMiddleware
    {
        private readonly HttpWebServer httpWebServer;

        public EventDispatcherMiddleware(HttpWebServer httpWebServer)
        {
            this.httpWebServer = httpWebServer;
        }

        protected override void Invoke(GameEvent gameEvent, MiddlewareDelegate next) =>
            httpWebServer.BroadcastWebSocketMessage(gameEvent);
    }
}