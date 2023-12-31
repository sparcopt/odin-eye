namespace OdinEye.Models.Api
{
    using System.Collections.Generic;
    using System.Linq;

    public class BossDetails
    {
        public int ActiveBosses { get; set; }
        public IEnumerable<Boss> Bosses { get; set; } = Enumerable.Empty<Boss>();
    }
}