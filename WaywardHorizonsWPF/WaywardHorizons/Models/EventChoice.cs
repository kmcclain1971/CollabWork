using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaywardHorizons.Characters;

namespace WaywardHorizons.Helpers
{
    public class EventChoice
    {
        public string ChoiceText { get; set; }
        public string ActionText { get; set; }
        public Action<Person> ActionToTake { get; set; }
    }
}
