namespace OdinEye.Http.Api.Controllers
{
    using Extensions;
    using Models.Api;
    using System.Collections.Generic;
    using System.Linq;
    using WebSocketSharp.Server;

    public class WorldDetailsController : IController
    {
        public string Route => "/worldDetails";

        public void OnGet(HttpRequestEventArgs requestArguments)
        {
            
            var worldDetails = new WorldDetails
            {
                DayNumber = EnvMan.instance.GetCurrentDay(),
                DayCycle = GetDayCycle(),
                WorldName = ZNet.instance.GetWorldName(),
                SeedName = ZNet.m_world.m_seedName,
                WorldKeys = ZNet.m_world.m_startingGlobalKeys,
                GlobalKeys = GetGlobalKeys()
            };
            
            requestArguments.Response.Ok(worldDetails);
        }

        private string GetDayCycle()
        {
            if (EnvMan.instance.IsNight())
            {
                return "night";
            }

            if (EnvMan.instance.IsDay())
            {
                return EnvMan.instance.IsAfternoon() ? "afternoon" : "morning";
            }

            return "unknown";
        }

        private IEnumerable<GlobalKey> GetGlobalKeys() =>
            ZoneSystem.instance.m_globalKeysValues.Count == 0
                ? Enumerable.Empty<GlobalKey>()
                : ZoneSystem.instance.m_globalKeysValues.Select(key => new GlobalKey { Name = key.Key, Value = key.Value });
    }
}