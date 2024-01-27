namespace OdinEye.Extensions
{
    using Models;
    using System.Collections.Generic;

    public static class ZNetExtensions
    {
        public static IEnumerable<Peer> GetAllPeers(this ZNet znet)
        {
            foreach (var peer in znet.m_peers)
            {
                if (peer.IsReady() && !peer.m_characterID.IsNone())
                {
                    var zdo = ZDOMan.instance.GetZDO(peer.m_characterID);
                    if (zdo == null)
                    {
                        continue;
                    }

                    zdo.GetFloat(ZDOVars.s_health, out var health);
                    zdo.GetFloat(ZDOVars.s_maxHealth, out var maxHealth);
                    zdo.GetFloat(ZDOVars.s_stamina, out var stamina);
                            
                    yield return new Peer
                    {
                        CharacterId = peer.m_characterID.ToString(),
                        Name = peer.m_playerName,
                        SteamId = peer.m_socket.GetHostName(),
                        Health = health,
                        MaxHealth = maxHealth,
                        Stamina = stamina
                    };
                }
            }
        }
    }
}