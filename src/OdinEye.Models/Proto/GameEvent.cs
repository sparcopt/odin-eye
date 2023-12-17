namespace OdinEye.Models.Proto
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract]
    public class GameEvent : Message
    {
        [ProtoMember(1)]
        public string Message { get; set; }
        
        [ProtoMember(2)]
        public EventType Type { get; set; }
        
        [ProtoMember(4)]
        public Player Player { get; set; }
        
        [ProtoMember(5)]
        public IDictionary<string, object> Data { get; set; }

        public static GameEvent New(EventType type, string message, Player player = null) =>
            new GameEvent
            {
                CreatedDate = DateTime.UtcNow,
                Type = type,
                Message = message,
                Player = player
            };
    }
}