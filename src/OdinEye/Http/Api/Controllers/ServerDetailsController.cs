namespace OdinEye.Http.Api.Controllers
{
    using Extensions;
    using Models.Api;
    using WebSocketSharp.Server;

    public class ServerDetailsController : IController
    {
        public string Route => "/serverDetails";

        public void OnGet(HttpRequestEventArgs requestArguments)
        {
            var serverDetails = new ServerDetails
            {
                MaxNumberOfPlayers = ZNet.ServerPlayerLimit,
                GameVersion = Version.GetVersionString(),
                SteamAppId = SteamManager.APP_ID.ToString()
            };
            
            requestArguments.Response.Ok(serverDetails);
        }
    }
}