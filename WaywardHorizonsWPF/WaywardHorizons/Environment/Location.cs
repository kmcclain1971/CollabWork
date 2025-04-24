using WaywardHorizons.Characters;
using WaywardHorizons.Helpers;
using System.ComponentModel.DataAnnotations;

namespace WaywardHorizons.Environment
{
    internal class Location
    {
        private readonly IUtility _utility = new Utility();
        private List<Event> _events;

        [Required] public int LocationId { get; set; }
        [Required] public string LocationName { get; set; }
        public List<Person>? People { get; set; }
        public List<NPC>? NPCs { get; set; }

        public Location()
        {
            
        }

        public void Explore(Person adventurer)
        {
            _utility.Clear();
            // write the header
            _utility.WriteHeader(adventurer);

            _utility.Print("What would you like to do?");

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
            Console.WriteLine("Congratulations you've seen all that this location has to offer! \nReturn to the main menu to explore the other locations!");
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

        /// <summary>
        /// This sets up events for a location and returns the set based on the locationId value passed
        /// In addition, the Event object now has a locationId property to really tie an event to a location if needed
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        /// <remarks>Took general inspiration from Oregon Trail gameplay. Used Microsoft Copilot for example of code to demonstrate how events worked in that game.</remarks>
        public List<Event> GenerateEvents(int locationId)
        {
            var setOne = new List<Event>
            {
                    new Event(locationId,"You encounter a river crossing. Do you attempt to cross?", new Dictionary<string, Action<Person>>
                    {
                        {"Cross", p => p.UpdateStatus(-20, 0)},
                        {"Wait", p => p.UpdateStatus(0, -10)},
                    }),
                    new Event(locationId,"A sudden storm destroys your shelter. Do you search for a new shelter or try to rebuild?", new Dictionary<string, Action<Person>>
                    {
                        {"Search for new Shelter", p => p.UpdateStatus(-10, 0)},
                        {"Rebuild", p => p.UpdateStatus(0, -10)},
                    }),
                    new Event(locationId,"A traveler offers to join your group, but they need supplies. Do you accept them?", new Dictionary<string, Action<Person>>
                    {
                        {"Accept", p => p.UpdateStatus(0, -15)},
                        {"Decline", p => p.UpdateStatus(0, 0)},
                    }),
                    new Event(locationId,"You find a berry bush. Do you risk eating the berries?", new Dictionary<string, Action<Person>>
                    {
                        {"Eat", p => p.UpdateStatus(-10, +20)},
                        {"Ignore", p => p.UpdateStatus(0, 0)},
                    }),
                    new Event(locationId,"A snake bites you! Do you try to suck the poison out or seek help?", new Dictionary<string, Action<Person>>
                    {
                        {"Suck the Poison", p => p.UpdateStatus(-25, 0)},
                        {"Seek Help", p => p.UpdateStatus(-15, -10)},
                    })
                };

            var setTwo = new List<Event>
                {
                    new Event(locationId,"You encounter a group of thieving goblins demanding supplies from your group. Do you fight the group or meet their demands?", new Dictionary<string, Action<Person>>
                    {
                        {"Fight", p => p.UpdateStatus(-40, 0)},
                        {"Meet Demands", p => p.UpdateStatus(0, -20)},
                    }),
                    new Event(locationId,"You find an abandoned campsite. Do you stop and look around or continue your journey?", new Dictionary<string, Action<Person>>
                    {
                        {"Stop and Look", p => p.UpdateStatus(0, +10)},
                        {"Continue", p => p.UpdateStatus(0, -10)},
                    }),
                    new Event(locationId,"A wandering trader offers you healing potions in exhange for supplies. Do you trade with them?", new Dictionary<string, Action<Person>>
                    {
                        {"Trade", p => p.UpdateStatus(+15, -15)},
                        {"Decline", p => p.UpdateStatus(0, 0)},
                    }),
                    new Event(locationId,"A dragon appears! Do you fight the dragon or Flee?", new Dictionary<string, Action<Person>>
                    {
                        {"Fight", p => p.UpdateStatus(-100, 0)},
                        {"Flee", p => p.UpdateStatus(0, -10)},
                    }),
                    new Event(locationId,"A spider bites you! Do you try to suck the poison out or seek help?", new Dictionary<string, Action<Person>>
                    {
                        {"Suck the Poison", p => p.UpdateStatus(-25, 0)},
                        {"Seek Help", p => p.UpdateStatus(-15, -10)},
                    })
                };

            var setThree = new List<Event>
                {
                    new Event(locationId,"You encounter a dungeon. Do you attempt to explore?", new Dictionary<string, Action<Person>>
                    {
                        {"Explore", p => p.UpdateStatus(-20, 0)},
                        {"Continue", p => p.UpdateStatus(0, -10)},
                    }),
                    new Event(locationId,"You see a mystical griffin! Would you like to hunt it or leave it be?", new Dictionary<string, Action<Person>>
                    {
                        {"Hunt", p => p.UpdateStatus(-50, -30)},
                        {"Leave it be", p => p.UpdateStatus(0, -10)},
                    }),
                    new Event(locationId,"You encounter a mysterious merchant. Do you purchase their wares?", new Dictionary<string, Action<Person>>
                    {
                        {"Purchase", p => p.UpdateStatus(-15, +10)},
                        {"Decline", p => p.UpdateStatus(0, 0)},
                    }),
                    new Event(locationId,"A wild wolf approaches! Do you fight or try to scare it away?", new Dictionary<string, Action<Person>>
                    {
                        {"Fight", p => p.UpdateStatus(-20, +15)},
                        {"Scare it away", p => p.UpdateStatus(-10, 0)},
                    }),
                    new Event(locationId,"A dense fog engulfs your surroundings. Do you press forward or wait it out?", new Dictionary<string, Action<Person>>
                    {
                        {"Press forward", p => p.UpdateStatus(-10, -10)},
                        {"Wait it out", p => p.UpdateStatus(0, 0)},
                    })
                };

            var setFour = new List<Event>
                {
                    new Event(locationId,"A raging river blocks your path. Do you try to cross or find another way?", new Dictionary<string, Action<Person>>
                    {
                        {"Cross", p => p.UpdateStatus(-30, 0)},
                        {"Find another way", p => p.UpdateStatus(0, -15)},
                    }),
                    new Event(locationId, "A rickety bridge spans a deep chasm. Do you risk crossing it?", new Dictionary<string, Action<Person>>
                    {
                        {"Cross", p => p.UpdateStatus(-100, -100)},
                        {"Turn back", p => p.UpdateStatus(0, -10)},
                    }),
                    new Event(locationId,"You discover a treasure chest. Do you open it or leave it untouched", new Dictionary<string, Action<Person>>
                    {
                        {"Open", p => p.UpdateStatus(-10, +50)},
                        {"Leave it", p => p.UpdateStatus(0, 0)},
                    }),
                    new Event(locationId,"A rouge offers you a rare map in exhange for some food. Do you accept", new Dictionary<string, Action<Person>>
                    {
                        {"Accept", p => p.UpdateStatus(-0, -15)},
                        {"Decline", p => p.UpdateStatus(0, 0)},
                    }),
                    new Event(locationId,"An enchanted tree offers you a blessing--for a sacrifice. Do you accept?", new Dictionary<string, Action<Person>>
                    {
                        {"Accept", p => p.UpdateStatus(-25, +50)},
                        {"Decline", p => p.UpdateStatus(0, -10)},
                    })
                };

            var setFive = new List<Event>
                {
                    new Event(locationId,"You stumble upon a glowing pool. Do you drink from it or avoid it?", new Dictionary<string, Action<Person>>
                    {
                        {"Drink", p => p.UpdateStatus(+20, -15)},
                        {"Avoid", p => p.UpdateStatus(0, -10)},
                    }),
                    new Event(locationId,"A group of villagers request help defending against raiders. Do you assist?", new Dictionary<string, Action<Person>>
                    {
                        {"Assist", p => p.UpdateStatus(-30, +50)},
                        {"Decline", p => p.UpdateStatus(0, -10)},
                    }),
                    new Event(locationId,"A mystical beast blocks your path. Do challenge it or wait?", new Dictionary<string, Action<Person>>
                    {
                        {"Challenge", p => p.UpdateStatus(-40, +30)},
                        {"Wait", p => p.UpdateStatus(0, -5)},
                    }),
                    new Event(locationId,"A traveling bard offers to teach you a song for a price. Do you agree?", new Dictionary<string, Action<Person>>
                    {
                        {"Agree", p => p.UpdateStatus(-0, -20)},
                        {"Decline", p => p.UpdateStatus(0, 0)},
                    }),
                    new Event(locationId,"You encounter a magical fountain that promises great power. Do you step in?", new Dictionary<string, Action<Person>>
                    {
                        {"Step in", p => p.UpdateStatus(+100, 0)},
                        {"Avoid", p => p.UpdateStatus(-15, -10)},
                    })
                };

            // logic to return appropriate set
            switch (locationId)
            {
                case 1:
                    _events = setOne;
                    return setOne;
                case 2:
                    _events = setTwo;
                    return setTwo;
                case 3:
                    _events = setThree;
                    return setThree;
                case 4:
                    _events = setFour;
                    return setFour;
                case 5:
                    _events = setFive;
                    return setFive;
                default:
                    _events = setOne;
                    return setOne;
            }
        }

        private List<NPC> PopulateLocationNPCList()
        {
            var npcList = new List<NPC>();
            int numbernpcs = _utility.GetRandomNumber(2, 3);

            for (int i = 0; i <= numbernpcs; i++)
            {
                var npc = new NPC(); // generate NPC object
                npcList.Add(npc);
            }

            return npcList;
        }
    }
}
