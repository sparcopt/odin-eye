namespace OdinEye.Models.Proto
{
    using ProtoBuf;
    using System;

    [ProtoContract]
    public class Player
    {
        [ProtoMember(1)]
        public Guid Id { get; set; }
        
        [ProtoMember(2)]
        public string CharacterId { get; set; }
        
        [ProtoMember(3)]
        public string SteamId { get; set; }
        
        [ProtoMember(4)]
        public string Name { get; set; }
        
        [ProtoMember(5)]
        public float Health { get; set; }
        
        [ProtoMember(6)]
        public float MaxHealth { get; set; }
        
        [ProtoMember(7)]
        public float Stamina { get; set; }
    }
}