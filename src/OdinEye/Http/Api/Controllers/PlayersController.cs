namespace OdinEye.Http.Api.Controllers
{
    using Extensions;
    using System.Collections.Generic;
    using WebSocketSharp.Server;

    public class PlayersController : IController
    {
        public string Route => "/players";

        public void OnGet(HttpRequestEventArgs requestArguments)
        {
            var players = new List<Models.Player>();
                    
            foreach (var peer in ZNet.instance.m_peers)
            {
                if (peer.IsReady() && !peer.m_characterID.IsNone())
                {
                    var zdo = ZDOMan.instance.GetZDO(peer.m_characterID);
                    if (zdo == null)
                    {
                        return;
                    }

                    zdo.GetFloat(ZDOVars.s_health, out var health);
                    zdo.GetFloat(ZDOVars.s_maxHealth, out var maxHealth);
                    zdo.GetFloat(ZDOVars.s_stamina, out var stamina);
                            
                    players.Add(new Models.Player
                    {
                        Id = peer.m_characterID.ToString(),
                        Name = peer.m_playerName,
                        SteamId = peer.m_socket.GetHostName(),
                        Health = health,
                        MaxHealth = maxHealth,
                        Stamina = stamina
                    });
                }
            }
            
            requestArguments.Response.Ok(players);
        }
    }
}