using System.Windows;
using WaywardHorizons.Helpers;

namespace WaywardHorizons.Characters
{
    public class Person
    {
        #region Properties
        public string PlayerName {  get; set; }
        public int Health { get; set; } = 100;
        public int Supplies { get; set; } = 100;
        #endregion

        #region Constructor
        public Person () { }
        #endregion

        #region Public Methods
        public void ChangeName(string newName)
        {
            if (!string.IsNullOrWhiteSpace(newName))
            {
                PlayerName = newName;
                Console.WriteLine($"Player name is: {PlayerName}");
            }
            else
            {
                Console.WriteLine("Invalid name. Please try again.");
            }
        }


        public void UpdateStatus(int healthChange, int suppliesChange)
        {
            Health += healthChange;
            Supplies += suppliesChange;

            if (Health < 0) Health = 0;
            if (Supplies < 0) Supplies = 0;
        }

        #endregion

    }
}
