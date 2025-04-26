using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaywardHorizons.Accessories;

namespace WaywardHorizons.Characters
{
    public class Person
    {
        #region Properties
        public string PlayerName {  get; set; }
        public int Health { get; set; } = 100;
        public int Supplies { get; set; } = 100;
        public List<Item> Items { get; set; }
        #endregion

        #region Constructor
        public Person ()
        {
            
        }
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

        public void Equip(WearableItem item)
        {
            //code here to "equip a wearable item"
            throw new NotImplementedException();
        }

        public void Use(Item item)
        {
            //code here to "use an item"
            throw new NotImplementedException();
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
