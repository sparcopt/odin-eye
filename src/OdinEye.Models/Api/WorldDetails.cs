namespace OdinEye.Models.Api
{
    using System.Collections.Generic;
    using System.Linq;

    public class WorldDetails
    {
        public int DayNumber { get; set; }
        public string DayCycle { get; set; }
        public string WorldName { get; set; }
        public string SeedName { get; set; }
        public IEnumerable<string> WorldKeys { get; set; } = Enumerable.Empty<string>();
    }
}