using WaywardHorizons.Characters;
using WaywardHorizons.Helpers;

namespace WaywardHorizons.Interfaces
{
    public interface IUtilityService
    {
        List<Event> GenerateEvents(int locationId);
        Person ParseEvent(Action<Person> eventAction, Person adventurer);

    }
}