namespace OdinEye.Events
{
    using Middlewares;
    using Models.Proto;
    using System;

    public class EventHandler
    {
        private IEventMiddleware rootMiddleware;
        
        public void Configure(Action<EventHandlerConfigurationOptions> configurator)
        {
            var options = new EventHandlerConfigurationOptions();
            configurator(options);
            rootMiddleware = options.RootMiddleware;
        }

        public void Handle(GameEvent gameEvent)
        {
            rootMiddleware.Handle(gameEvent);
        }
    }
}