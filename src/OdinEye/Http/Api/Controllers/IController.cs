namespace OdinEye.Http.Api.Controllers
{
    using WebSocketSharp.Server;

    public interface IController
    {
        string Route { get; }
        void OnGet(HttpRequestEventArgs requestArguments);
    }
}