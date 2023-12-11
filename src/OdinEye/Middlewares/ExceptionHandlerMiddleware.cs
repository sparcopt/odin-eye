namespace OdinEye.Middlewares
{
    using Logging;
    using System;

    public class ExceptionHandlerMiddleware : EventMiddleware
    {
        private readonly ILogger logger;

        public ExceptionHandlerMiddleware(ILogger logger)
        {
            this.logger = logger;
        }
        
        protected override void Invoke(GameEvent gameEvent, MiddlewareDelegate next)
        {
            try
            {
                next(gameEvent);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error while handling game event: {ex.Message}");
            }
        }
    }
}