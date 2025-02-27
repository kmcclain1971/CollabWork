using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptAFish_v2.Tanks
{
    public class Tank
    {
        public List<Fish> Fishs { get; set; } = new List<Fish>();

        public Tank() { }
    }
}
