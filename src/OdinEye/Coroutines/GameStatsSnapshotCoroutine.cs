namespace OdinEye.Coroutines
{
    using Http;
    using Models.Proto;
    using System;
    using System.Collections;
    using System.Linq;
    using UnityEngine;

    public class GameStatsSnapshotCoroutine
    {
        private readonly HttpWebServer httpWebServer;

        public GameStatsSnapshotCoroutine(HttpWebServer httpWebServer)
        {
            this.httpWebServer = httpWebServer;
        }
        
        public IEnumerator SendGameStatsSnapshotCoroutine()
        {
            while (true)
            {
                SendGameStatsSnapshot();
                yield return new WaitForSeconds(1f);
            }
        }

        private void SendGameStatsSnapshot()
        {
            var worldStats = new WorldStats
            {
                DayNumber = EnvMan.instance.GetCurrentDay(),
                DayCycle = EnvMan.instance.IsDay() ? "day" : "night"
            };

            var playerStats = ZNet.instance.GetAllCharacterZDOS().Select(zdo =>
            {
                zdo.GetFloat(ZDOVars.s_health, out var health);
                zdo.GetFloat(ZDOVars.s_maxHealth, out var maxHealth);
                zdo.GetFloat(ZDOVars.s_stamina, out var stamina);

                return new PlayerStats
                {
                    Id = zdo.m_uid.ToString(),
                    Health = health,
                    MaxHealth = maxHealth,
                    Stamina = stamina
                };
            });

            var gameStatsSnapshot = new GameStatsSnapshot
            {
                CreatedDate = DateTime.UtcNow,
                PlayerStats = playerStats,
                WorldStats = worldStats
            };
            
            httpWebServer.BroadcastWebSocketMessage(gameStatsSnapshot);
        }
    }
}