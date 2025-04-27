using Microsoft.Extensions.Logging;
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

        /// <summary>
        /// This sets up events for a location and returns the set based on the locationId value passed
        /// In addition, the Event object now has a locationId property to really tie an event to a location if needed
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        /// <remarks>Took general inspiration from Oregon Trail gameplay. Used Microsoft Copilot for example of code to demonstrate how events worked in that game.</remarks>
        public List<Event> GenerateEvents(int locationId)
        {
            var setLake = new List<Event>
            {
                    new Event(locationId,"You encounter a river crossing. Do you attempt to cross?",
                    [
                            new EventChoice() { ChoiceText = "- Cross", ActionText = "Health: -10", ActionToTake = p => p.UpdateStatus(-10, 0) },
                            new EventChoice() { ChoiceText = "- Wait", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                    new Event(locationId,"A sudden storm destroys your shelter. Do you search for a new shelter or try to rebuild?",
                    [
                            new EventChoice() { ChoiceText = "- Search for new Shelter", ActionText = "Health: -10", ActionToTake = p => p.UpdateStatus(-10, 0) },
                            new EventChoice() { ChoiceText = "- Rebuild", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                     new Event(locationId,"A traveler offers to join your group, but they need supplies. Do you accept them??",
                    [
                            new EventChoice() { ChoiceText = "- Accept", ActionText = "Health: -0", ActionToTake = p => p.UpdateStatus(-0, 0) },
                            new EventChoice() { ChoiceText = "- Decline", ActionText = "Supplies: -15", ActionToTake = p => p.UpdateStatus(0, -15)}
                    ]),
                     new Event(locationId,"You find a berry bush. Do you risk eating the berries?",
                    [
                            new EventChoice() { ChoiceText = "- Eat", ActionText = "Health: -20", ActionToTake = p => p.UpdateStatus(-20, 0) },
                            new EventChoice() { ChoiceText = "- Ignore", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                    new Event(locationId,"A snake bites you! Do you try to suck the poison out or seek help?",
                    [
                            new EventChoice() { ChoiceText = "- Suck the Poison", ActionText = "Health: -20", ActionToTake = p => p.UpdateStatus(-20, 0) },
                            new EventChoice() { ChoiceText = "- Seek Help", ActionText = "Supplies: -30", ActionToTake = p => p.UpdateStatus(0, -30)}
                    ]),

                };

            var setForest = new List<Event>
            {
                 new Event(locationId,"You encounter a group of thieving goblins demanding supplies from your group. Do you fight the group or meet their demands?",
                    [
                            new EventChoice() { ChoiceText = "- Fight", ActionText = "Health: -40", ActionToTake = p => p.UpdateStatus(-10, 0) },
                            new EventChoice() { ChoiceText = "- Meet Demands", ActionText = "Supplies: -20", ActionToTake = p => p.UpdateStatus(0, -20)}
                    ]),
                 new Event(locationId,"\"You find an abandoned campsite. Do you stop and look around or continue your journey?\"",
                    [
                            new EventChoice() { ChoiceText = "- Stop and Look", ActionText = "Health: -0", ActionToTake = p => p.UpdateStatus(-0, 0) },
                            new EventChoice() { ChoiceText = "- Continue", ActionText = "Supplies: -20", ActionToTake = p => p.UpdateStatus(0, -20)}
                    ]),
                 new Event(locationId,"A wandering trader offers you healing potions in exhange for supplies. Do you trade with them?",
                    [
                            new EventChoice() { ChoiceText = "- Ignore", ActionText = "Health: -0", ActionToTake = p => p.UpdateStatus(-0, 0) },
                            new EventChoice() { ChoiceText = "- Trade", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                 new Event(locationId,"A dragon appears! Do you fight the dragon or Flee?",
                    [
                            new EventChoice() { ChoiceText = "- Fight", ActionText = "Health: -100", ActionToTake = p => p.UpdateStatus(-100, 0) },
                            new EventChoice() { ChoiceText = "- Flee", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                 new Event(locationId,"A spider bites you! Do you try to suck the poison out or seek help?",
                    [
                            new EventChoice() { ChoiceText = "- Suck the Poison", ActionText = "Health: -25", ActionToTake = p => p.UpdateStatus(-25, 0) },
                            new EventChoice() { ChoiceText = "- Seek Help", ActionText = "Supplies: -25", ActionToTake = p => p.UpdateStatus(0, -25)}
                    ]),

            };

            var setDesert = new List<Event>
            {
                new Event(locationId,"You encounter a dungeon. Do you attempt to explore?",
                    [
                            new EventChoice() { ChoiceText = "- Explore", ActionText = "Health: -20", ActionToTake = p => p.UpdateStatus(-20, 0) },
                            new EventChoice() { ChoiceText = "- Continue", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                new Event(locationId,"You see a mystical griffin! Would you like to hunt it or leave it be?",
                    [
                            new EventChoice() { ChoiceText = "- Hunt", ActionText = "Health: -70", ActionToTake = p => p.UpdateStatus(-70, 0) },
                            new EventChoice() { ChoiceText = "- Leave it be", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                new Event(locationId,"You encounter a mysterious merchant. Do you purchase their wares?",
                    [
                            new EventChoice() { ChoiceText = "- Decline", ActionText = "Health: -0", ActionToTake = p => p.UpdateStatus(-0, 0) },
                            new EventChoice() { ChoiceText = "- Purchase", ActionText = "Supplies: +40", ActionToTake = p => p.UpdateStatus(0, +40)}
                    ]),
                new Event(locationId,"A wild wolf approaches! Do you fight or try to scare it away?",
                    [
                            new EventChoice() { ChoiceText = "- Fight", ActionText = "Health: -20", ActionToTake = p => p.UpdateStatus(-20, 0) },
                            new EventChoice() { ChoiceText = "- Scare it away", ActionText = "Supplies: -0", ActionToTake = p => p.UpdateStatus(0, -0)}
                    ]),
                new Event(locationId,"You encounter a mysterious merchant. Do you purchase their wares?",
                    [
                            new EventChoice() { ChoiceText = "- Decline", ActionText = "Health: -0", ActionToTake = p => p.UpdateStatus(-0, 0) },
                            new EventChoice() { ChoiceText = "- Purchase", ActionText = "Supplies: +40", ActionToTake = p => p.UpdateStatus(0, +40)}
                    ]),
                new Event(locationId,"A dense fog engulfs your surroundings. Do you press forward or wait it out?",
                    [
                            new EventChoice() { ChoiceText = "- Press forward", ActionText = "Health: -50", ActionToTake = p => p.UpdateStatus(-50, 0) },
                            new EventChoice() { ChoiceText = "- Wait it out", ActionText = "Supplies: -0", ActionToTake = p => p.UpdateStatus(0, -0)}
                    ]),

            };

            var setGrove = new List<Event>
            {
                new Event(locationId,"A raging river blocks your path. Do you try to cross or find another way?",
                    [
                            new EventChoice() { ChoiceText = "- Cross", ActionText = "Health: -30", ActionToTake = p => p.UpdateStatus(-30, 0) },
                            new EventChoice() { ChoiceText = "- Find another way", ActionText = "Supplies: -20", ActionToTake = p => p.UpdateStatus(0, -20)}
                    ]),
                new Event(locationId,"A rickety bridge spans a deep chasm. Do you risk crossing it?",
                    [
                            new EventChoice() { ChoiceText = "- Cross", ActionText = "Health: -100", ActionToTake = p => p.UpdateStatus(-100, 0) },
                            new EventChoice() { ChoiceText = "- Turn back", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                new Event(locationId,"You discover a treasure chest. Do you open it or leave it untouched",
                    [
                            new EventChoice() { ChoiceText = "- Open", ActionText = "Health: -10", ActionToTake = p => p.UpdateStatus(-10, +30) },
                            new EventChoice() { ChoiceText = "- Leave it", ActionText = "Supplies: -0", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                new Event(locationId,"A rouge offers you a rare map in exhange for some food. Do you accept",
                    [
                            new EventChoice() { ChoiceText = "- Accept", ActionText = "Health: -0", ActionToTake = p => p.UpdateStatus(-0, -10) },
                            new EventChoice() { ChoiceText = "- Decline", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                new Event(locationId,"An enchanted tree offers you a blessing--for a sacrifice. Do you accept?",
                    [
                            new EventChoice() { ChoiceText = "- Accept", ActionText = "Health: -20", ActionToTake = p => p.UpdateStatus(-20, +50) },
                            new EventChoice() { ChoiceText = "- Decline", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                
            };

            var setSwamp = new List<Event>
            {
                new Event(locationId,"You stumble upon a glowing pool. Do you drink from it or avoid it?",
                    [
                            new EventChoice() { ChoiceText = "- Drink", ActionText = "Health: +20", ActionToTake = p => p.UpdateStatus(+20, 0) },
                            new EventChoice() { ChoiceText = "- Avoid", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                new Event(locationId,"A group of villagers request help defending against raiders. Do you assist?",
                    [
                            new EventChoice() { ChoiceText = "- Assist", ActionText = "Health: -30", ActionToTake = p => p.UpdateStatus(-300, +50) },
                            new EventChoice() { ChoiceText = "- Decline", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                new Event(locationId,"A mystical beast blocks your path. Do challenge it or wait?A mystical beast blocks your path. Do challenge it or wait?",
                    [
                            new EventChoice() { ChoiceText = "- Challenge", ActionText = "Health: -100", ActionToTake = p => p.UpdateStatus(-100, -0) },
                            new EventChoice() { ChoiceText = "- Wait", ActionText = "Supplies: -0", ActionToTake = p => p.UpdateStatus(0, -0)}
                    ]),
                new Event(locationId,"A traveling bard offers to teach you a song for a price. Do you agree?",
                    [
                            new EventChoice() { ChoiceText = "- Accept", ActionText = "Health: -0", ActionToTake = p => p.UpdateStatus(-0, -10) },
                            new EventChoice() { ChoiceText = "- Decline", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                new Event(locationId,"You encounter a magical fountain that promises great power. Do you step in?",
                    [
                            new EventChoice() { ChoiceText = "- Step in", ActionText = "Health: +100", ActionToTake = p => p.UpdateStatus(+100, +50) },
                            new EventChoice() { ChoiceText = "- Avoid", ActionText = "Supplies: -10", ActionToTake = p => p.UpdateStatus(0, -10)}
                    ]),
                
            };

            // logic to return appropriate set
            switch (locationId)
            {
                case 1:
                    return setLake;
                case 2:
                    return setDesert;
                case 3:
                    return setForest;
                case 4:
                    return setGrove;
                case 5:
                    return setSwamp;
                default:
                    return setLake;
            }
        }

        //<summary>//
        // on an incorrect input I am attempting to make it so that the event gets repeated with an option to try again
        public Person ParseEvent(Action<Person> eventAction, Person adventurer)
        {
            eventAction.Invoke(adventurer);
            return adventurer;
        }

    }
}
