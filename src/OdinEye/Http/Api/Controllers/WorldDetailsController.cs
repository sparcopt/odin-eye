namespace OdinEye.Http.Api.Controllers
{
    using Extensions;
    using Models.Api;
    using WebSocketSharp.Server;

    public class WorldDetailsController : IController
    {
        public string Route => "/worldDetails";

        public void OnGet(HttpRequestEventArgs requestArguments)
        {
            var worldDetails = new WorldDetails
            {
                DayNumber = EnvMan.instance.GetCurrentDay(),
                DayCycle = EnvMan.instance.IsDay() ? "day" : "night",
                WorldName = ZNet.instance.GetWorldName(),
                SeedName = ZNet.m_world.m_seedName,
                WorldKeys = ZNet.m_world.m_startingGlobalKeys
            };
            
            requestArguments.Response.Ok(worldDetails);
        }
    }
}