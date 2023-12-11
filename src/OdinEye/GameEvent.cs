namespace OdinEye
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [ProtoContract]
    [ProtoInclude(2, typeof(GameEvent))]
    [ProtoInclude(3, typeof(GameStatsSnapshot))]
    public class Message
    {
        [ProtoMember(1)]
        public DateTime CreatedDate { get; set; }
    }
    
    [ProtoContract]
    public class GameEvent : Message
    {
        [ProtoMember(1)]
        public string Message { get; set; }
        
        [ProtoMember(2)]
        public string Type { get; set; }
        
        // [ProtoMember(3)]
        // public Models.Player Player { get; set; }
        
        [ProtoMember(3)]
        public IDictionary<string, object> Data { get; set; }

        public GameEvent(DateTime createdDate, string message)
        {
            CreatedDate = createdDate;
            Message = message;
        }
    }
    
    [ProtoContract]
    public class GameStatsSnapshot : Message
    {
        [ProtoMember(1)] public IEnumerable<PlayerStats> PlayerStats { get; set; } = new List<PlayerStats>();
        
        [ProtoMember(2)]
        public WorldStats WorldStats { get; set; }
    }
    
    [ProtoContract]
    public class PlayerStats
    {
        [ProtoMember(1)]
        public string Id { get; set; }
        
        [ProtoMember(2)]
        public float Health { get; set; }
        
        [ProtoMember(3)]
        public float MaxHealth { get; set; }
        
        [ProtoMember(4)]
        public float Stamina { get; set; }
    }
    
    [ProtoContract]
    public class WorldStats
    {
        [ProtoMember(1)]
        public int DayNumber { get; set; }
        
        [ProtoMember(2)]
        public string DayCycle { get; set; }
    }
}