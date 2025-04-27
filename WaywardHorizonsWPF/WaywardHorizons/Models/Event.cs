using WaywardHorizons.Characters;

namespace WaywardHorizons.Helpers
{
    public class Event
    {
        private Dictionary<string, Action<Person>> _choices;
        private List<EventChoice> _choicesList;

        public string Description { get; }
        public int LocationId { get; set; }
        public List<EventChoice> Choices { get; set; }

        public Event(int locationId, string description, List<EventChoice> eventChoices)
        {
            Description = description;
            LocationId = locationId;
            Choices = eventChoices;
        }

        public Event(int locationId, string description, Dictionary<string, Action<Person>> choices, List<EventChoice> eventChoices)
        {
            Description = description;
            LocationId = locationId;
            _choices = choices;
            _choicesList = eventChoices;
        }
    }
}
