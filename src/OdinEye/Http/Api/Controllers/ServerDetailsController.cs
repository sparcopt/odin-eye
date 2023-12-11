namespace OdinEye.Http.Api.Controllers
{
    using Extensions;
    using WebSocketSharp.Server;

    public class ServerDetailsController : IController
    {
        public string Route => "/serverDetails";

        public void OnGet(HttpRequestEventArgs requestArguments)
        {
            var serverDetails = new
            {
                maxNumberOfPlayers = ZNet.ServerPlayerLimit,
                gameVersion = Version.GetVersionString(),
                steamId = SteamManager.APP_ID.ToString()
            };
            
            requestArguments.Response.Ok(serverDetails);
        }
    }
}