namespace OdinEye.Models.Proto
{
    using ProtoBuf;
    using System;

    [ProtoContract]
    [ProtoInclude(2, typeof(GameEvent))]
    [ProtoInclude(3, typeof(GameStatsSnapshot))]
    public class Message
    {
        [ProtoMember(1)]
        public DateTime CreatedDate { get; set; }
    }
}