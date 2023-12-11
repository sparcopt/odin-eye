namespace OdinEye.Middlewares
{
    using Logging;

    public class LoggingMiddleware : EventMiddleware
    {
        private readonly ILogger logger;

        public LoggingMiddleware(ILogger logger)
        {
            this.logger = logger;
        }

        protected override void Invoke(GameEvent gameEvent, MiddlewareDelegate next)
        {
            logger.LogInfo($"Handling game event: {gameEvent.Message}");
            next(gameEvent);
        }
    }
}