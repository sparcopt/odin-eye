namespace OdinEye.Http.Api.Controllers
{
    using Extensions;
    using Models.Api;
    using System.Collections.Generic;
    using System.Linq;
    using WebSocketSharp.Server;

    public class BossDetailsController : IController
    {
        private const string DefeatedKey = "defeated_";
        private const string ActiveBossesKey = "activebosses";
        private readonly IEnumerable<(string, string)> bossNameKeys = new (string, string)[]
        {
            ("Eikthyr", "eikthyr"),
            ("The Elder", "gdking"),
            ("Bonemass", "bonemass"),
            ("Moder", "dragon"),
            ("Yagluth", "goblinking"),
            ("The Queen", "queen")
        };
            
        public string Route => "/bossDetails";

        public void OnGet(HttpRequestEventArgs requestArguments)
        {
            var activeBossesValue = ZoneSystem.instance.m_globalKeysValues
                .FirstOrDefault(kvp => kvp.Key == ActiveBossesKey)
                .Value;

            var defeatedKeys = ZoneSystem.instance.m_globalKeysValues
                .Where(kvp => kvp.Key.StartsWith(DefeatedKey))
                .Select(kvp => kvp.Key)
                .ToHashSet();
            
            var bossDetails = new BossDetails
            {
                ActiveBosses = activeBossesValue != null ? int.Parse(activeBossesValue) : 0,
                Bosses = GetBosses(defeatedKeys)
            };
            
            requestArguments.Response.Ok(bossDetails);
        }

        private IEnumerable<Boss> GetBosses(ICollection<string> defeatedKeys)
        {
            foreach (var (bossName, bossKey) in bossNameKeys)
            {
                yield return new Boss
                {
                    Key = bossKey,
                    Name = bossName,
                    IsDefeated = defeatedKeys.Contains(DefeatedKey + bossKey)
                };
            }
        }
    }
}