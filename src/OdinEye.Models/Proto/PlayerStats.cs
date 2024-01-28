namespace OdinEye.Models.Proto
{
    using ProtoBuf;
    using System;

    [ProtoContract]
    public class PlayerStats
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        
        [ProtoMember(2)]
        public string CharacterId { get; set; }
        
        [ProtoMember(3)]
        public float Health { get; set; }
        
        [ProtoMember(4)]
        public float MaxHealth { get; set; }
        
        [ProtoMember(5)]
        public float Stamina { get; set; }
    }
}