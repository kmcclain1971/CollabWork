using Microsoft.Extensions.Logging;
using System.IO;
using System.Text;
using System.Windows.Controls;
using WaywardHorizons.Characters;
using WaywardHorizons.Helpers;
using WaywardHorizons.Interfaces;

namespace WaywardHorizons.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly ILogger<UtilityService> _logger;

        public UtilityService(ILogger<UtilityService> logger)
        {
            _logger = logger;
        }

        public Random RandomNumberGenerator = new Random();

        //overloaded method - more than one method with the same name
        public int GetRandomNumber(int max)
        {
            return RandomNumberGenerator.Next(max);
        }

        public int GetRandomNumber(int min, int max)
        {
            return RandomNumberGenerator.Next(min, max);
        }


        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Pause()
        {
            Print("Press any key to continue");
            Console.ReadKey();
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
                    new Event(locationId,"You encounter a river crossing. Do you attempt to cross?",
                    [
                            new EventChoice() { ChoiceText = "- Cross", ActionText = "Health: -10", ActionToTake = p => p.UpdateStatus(-10, 0) },
                            new EventChoice() { ChoiceText = "- Wait", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ])
                    //new Event(locationId,"A sudden storm destroys your shelter. Do you search for a new shelter or try to rebuild?", new Dictionary<string, Action<Person>>
                    //{
                    //    {"Search for new Shelter", p => p.UpdateStatus(-10, 0)},
                    //    {"Rebuild", p => p.UpdateStatus(0, -10)},
                    //}),
                    //new Event(locationId,"A traveler offers to join your group, but they need supplies. Do you accept them?", new Dictionary<string, Action<Person>>
                    //{
                    //    {"Accept", p => p.UpdateStatus(0, -15)},
                    //    {"Decline", p => p.UpdateStatus(0, 0)},
                    //}),
                    //new Event(locationId,"You find a berry bush. Do you risk eating the berries?", new Dictionary<string, Action<Person>>
                    //{
                    //    {"Eat", p => p.UpdateStatus(-10, +20)},
                    //    {"Ignore", p => p.UpdateStatus(0, 0)},
                    //}),
                    //new Event(locationId,"A snake bites you! Do you try to suck the poison out or seek help?", new Dictionary<string, Action<Person>>
                    //{
                    //    {"Suck the Poison", p => p.UpdateStatus(-25, 0)},
                    //    {"Seek Help", p => p.UpdateStatus(-15, -10)},
                    //})
                };

            //var setTwo = new List<Event>
            //    {
            //        new Event(locationId,"You encounter a group of thieving goblins demanding supplies from your group. Do you fight the group or meet their demands?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Fight", p => p.UpdateStatus(-40, 0)},
            //            {"Meet Demands", p => p.UpdateStatus(0, -20)},
            //        }),
            //        new Event(locationId,"You find an abandoned campsite. Do you stop and look around or continue your journey?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Stop and Look", p => p.UpdateStatus(0, +10)},
            //            {"Continue", p => p.UpdateStatus(0, -10)},
            //        }),
            //        new Event(locationId,"A wandering trader offers you healing potions in exhange for supplies. Do you trade with them?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Trade", p => p.UpdateStatus(+15, -15)},
            //            {"Decline", p => p.UpdateStatus(0, 0)},
            //        }),
            //        new Event(locationId,"A dragon appears! Do you fight the dragon or Flee?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Fight", p => p.UpdateStatus(-100, 0)},
            //            {"Flee", p => p.UpdateStatus(0, -10)},
            //        }),
            //        new Event(locationId,"A spider bites you! Do you try to suck the poison out or seek help?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Suck the Poison", p => p.UpdateStatus(-25, 0)},
            //            {"Seek Help", p => p.UpdateStatus(-15, -10)},
            //        })
            //    };

            //var setThree = new List<Event>
            //    {
            //        new Event(locationId,"You encounter a dungeon. Do you attempt to explore?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Explore", p => p.UpdateStatus(-20, 0)},
            //            {"Continue", p => p.UpdateStatus(0, -10)},
            //        }),
            //        new Event(locationId,"You see a mystical griffin! Would you like to hunt it or leave it be?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Hunt", p => p.UpdateStatus(-50, -30)},
            //            {"Leave it be", p => p.UpdateStatus(0, -10)},
            //        }),
            //        new Event(locationId,"You encounter a mysterious merchant. Do you purchase their wares?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Purchase", p => p.UpdateStatus(-15, +10)},
            //            {"Decline", p => p.UpdateStatus(0, 0)},
            //        }),
            //        new Event(locationId,"A wild wolf approaches! Do you fight or try to scare it away?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Fight", p => p.UpdateStatus(-20, +15)},
            //            {"Scare it away", p => p.UpdateStatus(-10, 0)},
            //        }),
            //        new Event(locationId,"A dense fog engulfs your surroundings. Do you press forward or wait it out?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Press forward", p => p.UpdateStatus(-10, -10)},
            //            {"Wait it out", p => p.UpdateStatus(0, 0)},
            //        })
            //    };

            //var setFour = new List<Event>
            //    {
            //        new Event(locationId,"A raging river blocks your path. Do you try to cross or find another way?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Cross", p => p.UpdateStatus(-30, 0)},
            //            {"Find another way", p => p.UpdateStatus(0, -15)},
            //        }),
            //        new Event(locationId, "A rickety bridge spans a deep chasm. Do you risk crossing it?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Cross", p => p.UpdateStatus(-100, -100)},
            //            {"Turn back", p => p.UpdateStatus(0, -10)},
            //        }),
            //        new Event(locationId,"You discover a treasure chest. Do you open it or leave it untouched", new Dictionary<string, Action<Person>>
            //        {
            //            {"Open", p => p.UpdateStatus(-10, +50)},
            //            {"Leave it", p => p.UpdateStatus(0, 0)},
            //        }),
            //        new Event(locationId,"A rouge offers you a rare map in exhange for some food. Do you accept", new Dictionary<string, Action<Person>>
            //        {
            //            {"Accept", p => p.UpdateStatus(-0, -15)},
            //            {"Decline", p => p.UpdateStatus(0, 0)},
            //        }),
            //        new Event(locationId,"An enchanted tree offers you a blessing--for a sacrifice. Do you accept?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Accept", p => p.UpdateStatus(-25, +50)},
            //            {"Decline", p => p.UpdateStatus(0, -10)},
            //        })
            //    };

            //var setFive = new List<Event>
            //    {
            //        new Event(locationId,"You stumble upon a glowing pool. Do you drink from it or avoid it?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Drink", p => p.UpdateStatus(+20, -15)},
            //            {"Avoid", p => p.UpdateStatus(0, -10)},
            //        }),
            //        new Event(locationId,"A group of villagers request help defending against raiders. Do you assist?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Assist", p => p.UpdateStatus(-30, +50)},
            //            {"Decline", p => p.UpdateStatus(0, -10)},
            //        }),
            //        new Event(locationId,"A mystical beast blocks your path. Do challenge it or wait?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Challenge", p => p.UpdateStatus(-40, +30)},
            //            {"Wait", p => p.UpdateStatus(0, -5)},
            //        }),
            //        new Event(locationId,"A traveling bard offers to teach you a song for a price. Do you agree?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Agree", p => p.UpdateStatus(-0, -20)},
            //            {"Decline", p => p.UpdateStatus(0, 0)},
            //        }),
            //        new Event(locationId,"You encounter a magical fountain that promises great power. Do you step in?", new Dictionary<string, Action<Person>>
            //        {
            //            {"Step in", p => p.UpdateStatus(+100, 0)},
            //            {"Avoid", p => p.UpdateStatus(-15, -10)},
            //        })
            //    };

            // logic to return appropriate set
            switch (locationId)
            {
                case 1:
                    return setOne;
                //case 2:
                //    return setTwo;
                //case 3:
                //    return setThree;
                //case 4:
                //    return setFour;
                //case 5:
                //    return setFive;
                default:
                    return setOne;
            }
        }

        public string GetTextFromExternalFile(string path)
        {
            string output = "";
            if (File.Exists(path))
            {
                //the sky is bright
                output = File.ReadAllText(path);
            }
            else
            {
                //doom and gloom
                return "File not found - or some other default text";
            }

            return output;
        }

        public string[] GetArrayTextFromExternalFile(string path)
        {
            string[] output;
            if (File.Exists(path))
            {
                //the sky is bright
                output = File.ReadAllLines(path);
            }

            return null;
        }

        public string GetNextStep(int locationId)
        {
            switch (locationId)
            {
                case 1:
                    Print(GetStepText("main")); // location specific eventually
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    Pause();
                    break;
            }
            return string.Empty;
        }

        /// <summary>
        /// This method should return step text for a given location
        /// </summary>
        /// <returns></returns>
        public string GetStepText(string textType)
        {
            var mainRoadTexts = new string[] { "Text 1", "Text 2" };
            var placesFoundTexts = new string[] { "Text 1", "Text 2" };
            var actionsTexts = new string[] { "Leave", "Fight" };

            switch (textType)
            {
                case "main":
                    break;
                case "place":
                    break;
                case "action":
                    break;
            }

            return string.Empty;
        }

        public void WriteTitle()
        {
            var titleSequence = new StringBuilder();
            titleSequence.Append("/*********************************************************************************************/\n");
            titleSequence.Append("/*                                                                                           */\n");
            titleSequence.Append("/*                                                                                           */\n");
            titleSequence.Append("/*                                  Wayward Horizons                                         */\n");
            titleSequence.Append("/*                                  by Conor McClain                                         */\n");
            titleSequence.Append("/*                                                                                           */\n");
            titleSequence.Append("/*                                                                                           */\n");
            titleSequence.Append("/*********************************************************************************************/\n");
            
            Console.Write(titleSequence.ToString());
        }

        public void WriteHeader(Person adventurer)
        {
            var titleSequence = new StringBuilder();
            titleSequence.Append("/*********************************************************************************************/\n");
            titleSequence.Append("/***********************            Wayward Horizons          ********************************/\n");
            titleSequence.Append("/********************  Adventurer: " + adventurer.PlayerName + " || Health: " + adventurer.Health + " || Supplies: " + adventurer.Supplies + "  ********************/\n");
            titleSequence.Append("/*********************************************************************************************/\n");
            titleSequence.Append("\n\n\n");

            Console.Write(titleSequence.ToString());
        }

        public void WriteFooter()
        {
            throw new NotImplementedException();
        }

        private string GenerateRandomLocationName()
        {
            // generate the random data for location names
            List<string> prefix = new List<string>() { "Mount", "Castle", "Village of", "Lake", "Valley of", "Desert of", "Forest of", "Realm of" };
            List<string> names = new List<string>() { "Badassiveness", "Awesomeness", "Fabulousness", "Fantazmicness", "Lava", "Ice", "Scarlet Rot", "Winterfell" };

            var locationName = $"{prefix[GetRandomNumber(prefix.Count)]} {names[GetRandomNumber(names.Count)]}";

            return locationName;
        }

        public void GetNextStep(object locationId)
        {
            throw new NotImplementedException();
        }


    }
}
