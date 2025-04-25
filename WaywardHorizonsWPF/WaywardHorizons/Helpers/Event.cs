using WaywardHorizons.Characters;

namespace WaywardHorizons.Helpers
{
    public class Event
    {
        private Dictionary<string, Action<Person>> _choices;


        public string Description { get; }
        public int LocationId { get; set; }

        public Event(int locationId, string description, Dictionary<string, Action<Person>> choices)
        {
            Description = description;
            LocationId = locationId;
            _choices = choices;
        }

        //<summary>//
        // on an incorrect input I am attempting to make it so that the event gets repeated with an option to try again
        public void Trigger(Person adventurer)
        {
            Console.WriteLine(Description);
            Console.WriteLine("Your choices (Case Sensitive):");
            foreach (var choice in _choices.Keys)
            {
                Console.WriteLine($"- {choice}");
            }
            Console.Write("Your choices:");
            string userChoice = Console.ReadLine();
            if (_choices.ContainsKey(userChoice))
            {
                _choices[userChoice].Invoke(adventurer);
                Console.WriteLine($"Health: {adventurer.Health}, Supplies: {adventurer.Supplies}\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid choice! Try again.\n");
                Trigger(adventurer);
               
            }
        }
    }
}
