using WaywardHorizons.Helpers;

namespace WaywardHorizons.Characters
{
    public class NPC : Person
    {
        private readonly IUtility utility = new Utility();
        // properties for NPC specific
        public string[] dialog;
        public string WelcomeText = "";

        public NPC()
        {
            List<string> prefix = new List<string>() { "Wizard", "Fisherman", "Knight", "Goblin", "Mysterious", "Friendly", "Mystical", "Ranger" };
            List<string> names = new List<string>() { "Phil", "Reggie", "Gargamel", "Bob", "Martha", "Jimbo", "Stewie", "Brian" };
            PlayerName = $"{prefix[utility.GetRandomNumber(0,prefix.Count)]} {names[utility.GetRandomNumber(0,names.Count)]}";
        }


        
    }
}
