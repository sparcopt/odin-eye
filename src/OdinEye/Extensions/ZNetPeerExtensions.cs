namespace OdinEye.Extensions
{
    using Models.Proto;

    public static class ZNetPeerExtensions
    {
        public static Player ToPlayer(this ZNetPeer peer) =>
            new Player
            {
                Id = peer.m_characterID.ToString(),
                Name = peer.m_playerName,
                SteamId = peer.m_socket.GetHostName()
            };
    }
}