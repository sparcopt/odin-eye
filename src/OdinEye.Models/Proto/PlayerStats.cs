namespace OdinEye.Models.Proto
{
    using ProtoBuf;

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
}