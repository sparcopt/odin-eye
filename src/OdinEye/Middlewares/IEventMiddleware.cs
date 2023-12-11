namespace OdinEye.Middlewares
{
    public interface IEventMiddleware
    {
        IEventMiddleware SetNext(EventMiddleware handler);

        void Handle(GameEvent gameEvent);
    }
}