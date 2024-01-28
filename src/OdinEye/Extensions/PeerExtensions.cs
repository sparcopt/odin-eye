namespace OdinEye.Extensions
{
    using Models;
    using Models.Proto;
    using System.Collections.Generic;
    using System.Linq;
    using Player = Models.Api.Player;

    public static class PeerExtensions
    {
        public static IEnumerable<Player> ToDto(this IEnumerable<Peer> peers) =>
            peers.Select(peer => new Player
            {
                Id = NameBasedGuid.NewPlayerGuid(peer.SteamId, peer.Name),
                CharacterId = peer.CharacterId,
                Name = peer.Name,
                SteamId = peer.SteamId,
                Health = peer.Health,
                MaxHealth = peer.MaxHealth,
                Stamina = peer.Stamina
            });
        
        public static IEnumerable<PlayerStats> ToPlayerStats(this IEnumerable<Peer> peers) =>
            peers.Select(peer => new PlayerStats
            {
                Id = NameBasedGuid.NewPlayerGuid(peer.SteamId, peer.Name),
                CharacterId = peer.CharacterId,
                Health = peer.Health,
                MaxHealth = peer.MaxHealth,
                Stamina = peer.Stamina
            });
    }
}