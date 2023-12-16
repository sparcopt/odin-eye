namespace OdinEye.Extensions
{
    using Models.Proto;

    public static class ZNetPeerExtensions
    {
        public static Player ToPlayer(this ZNetPeer peer)
        {
            var zdo = ZDOMan.instance.GetZDO(peer.m_characterID);
            zdo.GetFloat(ZDOVars.s_health, out var health);
            zdo.GetFloat(ZDOVars.s_maxHealth, out var maxHealth);
            zdo.GetFloat(ZDOVars.s_stamina, out var stamina);
                            
            return new Player
            {
                Id = peer.m_characterID.ToString(),
                Name = peer.m_playerName,
                SteamId = peer.m_socket.GetHostName(),
                Health = health,
                MaxHealth = maxHealth,
                Stamina = stamina
            };
        }
    }
}