using WaywardHorizons.Helpers;

namespace WaywardHorizons.Characters
{
    public class NPC : Person
    {
        private readonly IUtilityService _utility;
        // properties for NPC specific
        public string[] dialog;
        public string WelcomeText = "";

        public NPC(IUtilityService utilityService)
        {
            _utility = utilityService;
            List<string> prefix = new List<string>() { "Wizard", "Fisherman", "Knight", "Goblin", "Mysterious", "Friendly", "Mystical", "Ranger" };
            List<string> names = new List<string>() { "Phil", "Reggie", "Gargamel", "Bob", "Martha", "Jimbo", "Stewie", "Brian" };
            PlayerName = $"{prefix[_utility.GetRandomNumber(0,prefix.Count)]} {names[_utility.GetRandomNumber(0,names.Count)]}";
        }


        
    }
}
