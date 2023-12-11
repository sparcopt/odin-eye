namespace OdinEye.Http.Api.Controllers
{
    using Extensions;
    using WebSocketSharp.Server;

    public class WorldDetailsController : IController
    {
        public string Route => "/worldDetails";

        public void OnGet(HttpRequestEventArgs requestArguments)
        {
            var worldDetails = new
            {
                dayNumber = EnvMan.instance.GetCurrentDay(),
                dayCycle = EnvMan.instance.IsDay() ? "day" : "night",
                worldName = ZNet.instance.GetWorldName(),
                seedName = ZNet.m_world.m_seedName,
                worldKeys = ZNet.m_world.m_startingGlobalKeys
            };
            
            requestArguments.Response.Ok(worldDetails);
        }
    }
}