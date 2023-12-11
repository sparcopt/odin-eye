namespace OdinEye.Middlewares
{
    public delegate void MiddlewareDelegate(GameEvent gameEvent);
    
    public abstract class EventMiddleware : IEventMiddleware
    {
        private MiddlewareDelegate next;
        
        public IEventMiddleware SetNext(EventMiddleware handler)
        {
            next = handler.InvokeWithNextDelegate;
            return handler;
        }

        public void Handle(GameEvent gameEvent)
        {
            Invoke(gameEvent, next);
        }

        protected abstract void Invoke(GameEvent gameEvent, MiddlewareDelegate next);
        
        private void InvokeWithNextDelegate(GameEvent gameEvent)
        {
            Invoke(gameEvent, next ?? (_ => { }));
        }
    }
}