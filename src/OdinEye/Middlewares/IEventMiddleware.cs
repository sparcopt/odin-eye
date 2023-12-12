namespace OdinEye.Middlewares
{
    using Models.Proto;

    public interface IEventMiddleware
    {
        IEventMiddleware SetNext(EventMiddleware handler);

        void Handle(GameEvent gameEvent);
    }
}