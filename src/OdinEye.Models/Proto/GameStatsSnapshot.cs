namespace OdinEye.Models.Proto
{
    using ProtoBuf;
    using System.Collections.Generic;

    [ProtoContract]
    public class GameStatsSnapshot : Message
    {
        [ProtoMember(1)] public IEnumerable<PlayerStats> PlayerStats { get; set; } = new List<PlayerStats>();
        
        [ProtoMember(2)]
        public WorldStats WorldStats { get; set; }
    }
}