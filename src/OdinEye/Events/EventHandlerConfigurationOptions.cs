namespace OdinEye.Events
{
    using Middlewares;

    public class EventHandlerConfigurationOptions
    {
        public IEventMiddleware RootMiddleware { get; private set; }
        public IEventMiddleware LastMiddleware { get; private set; }
        
        public EventHandlerConfigurationOptions AddMiddleware(EventMiddleware eventMiddleware)
        {
            if (RootMiddleware == null)
            {
                RootMiddleware = eventMiddleware;
            }
            
            LastMiddleware?.SetNext(eventMiddleware);
            LastMiddleware = eventMiddleware;
            return this;
        }
    }
}