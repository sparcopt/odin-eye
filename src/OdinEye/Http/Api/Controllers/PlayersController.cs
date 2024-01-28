namespace OdinEye.Http.Api.Controllers
{
    using Extensions;
    using WebSocketSharp.Server;

    public class PlayersController : IController
    {
        public string Route => "/players";

        public void OnGet(HttpRequestEventArgs requestArguments)
        {
            var peers = ZNet.instance.GetAllPeers();
            requestArguments.Response.Ok(peers.ToDto());
        }
    }
}