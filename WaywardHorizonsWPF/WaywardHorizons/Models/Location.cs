using WaywardHorizons.Characters;
using WaywardHorizons.Interfaces;
using System.ComponentModel.DataAnnotations;
using WaywardHorizons.Helpers;

namespace WaywardHorizons.Models
{
    public class Location
    {
        private readonly IUtilityService _utility;
        private List<Event> _events;

        [Required] public int LocationId { get; set; }
        [Required] public string LocationName { get; set; }
        public List<Person>? People { get; set; }
        public List<NPC>? NPCs { get; set; }

        public Location(IUtilityService utility)
        {
            _utility = utility;
        }

        public void Explore(Person adventurer)
        {
            //_utility.Clear();
            // write the header
            //_utility.WriteHeader(adventurer);

            //_utility.Print("What would you like to do?");

            // the _events have been populated during the setup of each Location
            foreach (var gameEvent in _events)
            {
                gameEvent.Trigger(adventurer);
                Console.Clear();
                _utility.WriteHeader(adventurer);
                if (adventurer.Health <= 0)
                {
                    Console.WriteLine("You have succumbed to the hardships of the trail...");
                    return;
                }
            }
            Console.WriteLine("Congratulations you've seen all that this location has to offer! \nReturn to the location map to explore the other locations!");
        }

        public string GetNPCList()
        {
            string output = "";
            int number = 1;
            NPCs = PopulateLocationNPCList();

            if (NPCs != null)
            {
                foreach (NPC npcs in NPCs)
                {
                    output += $"       {number}.{npcs.PlayerName}\n";
                    number++;
                }
            }
            else
            {
                output += $"Suprise! There are no NPCS! :) \n";
            }

            return output;
        }

        

        private List<NPC> PopulateLocationNPCList()
        {
            var npcList = new List<NPC>();
            int numbernpcs = _utility.GetRandomNumber(2, 3);

            for (int i = 0; i <= numbernpcs; i++)
            {
                var npc = new NPC(_utility); // generate NPC object
                npcList.Add(npc);
            }

            return npcList;
        }
    }
}
