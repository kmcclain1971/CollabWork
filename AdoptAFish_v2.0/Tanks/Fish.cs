using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptAFish_v2.Tanks
{
    public class Fish
    {
        // properties
        public required string FishName { get; set; }
        public string? FishColor { get; set; }
        public string? Description { get; set; }
        public int? FishAge { get; set; }
        public double? Price { get; set; }

        public Fish() { }
    }
}
