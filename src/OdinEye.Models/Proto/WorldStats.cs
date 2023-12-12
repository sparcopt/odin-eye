namespace OdinEye.Models.Proto
{
    using ProtoBuf;

    [ProtoContract]
    public class WorldStats
    {
        [ProtoMember(1)]
        public int DayNumber { get; set; }
        
        [ProtoMember(2)]
        public string DayCycle { get; set; }
    }
}