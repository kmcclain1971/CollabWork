using WaywardHorizons.Characters;
using WaywardHorizons.Environment;
using Microsoft.Extensions.Logging;
using System.Text;
using System.IO;

namespace WaywardHorizons.Helpers
{
    internal class Utility : IUtility
    {
        private readonly ILogger<Utility> _logger;

        public Utility() { }

        public Utility(ILogger<Utility> logger)
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

        public List<Location> GenerateLocations()
        {
            var locations = new List<Location>();
            int numberLocations = GetRandomNumber(4, 5);

            //5 locations
            for (int i = 1; i <= numberLocations + 1; i++)
            {
                var location = GenerateLocation(i); // generates random location object
                locations.Add(location);
            }

            return locations;
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

        /// <summary>
        /// This method now takes care of setting the LocationId value and generating events for the location
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        private Location GenerateLocation(int locationId)
        {
            var location = new Location();
            location.LocationId = locationId;
            location.LocationName = GenerateRandomLocationName();
            // create the events for the location
            location.GenerateEvents(locationId); // this method call sets the _events list on the Location object

            return location;
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
