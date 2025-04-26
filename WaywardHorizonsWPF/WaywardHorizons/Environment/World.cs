using WaywardHorizons.Helpers;
using System.Text;

namespace WaywardHorizons.Environment
{
    internal class World : IWorld
    {
        // privates
        private int _x = 0;
        private int _y = 0;
        private readonly IUtility _utility;

        //properties
        public List<Location> Locations { get; set; }
        Location[,]? map;


        public World(IUtility utility)
        {
            _utility = utility;
            // create locations for this instance of world
            Locations = _utility.GenerateLocations();
        }

        /// <summary>
        /// This method will return the locations generated for this world object
        /// </summary>
        /// <returns></returns>        
        public string GetLocationList()
        {
            var output = new StringBuilder();
            output.Append("-----------------------------------------\n");
            output.Append("Locations in the world:\n");
            int number = 1;
            if (Locations != null)
            {
                foreach (Location location in Locations)
                {
                    output.Append($"   {number}.{location.LocationName}\n");
                    number++;
                }
            }
            else
            {
                output.Append($"Surprise! There are no locations! :) \n");
            }
            output.Append("-----------------------------------------\n");

            return output.ToString();
        }
    }
}
