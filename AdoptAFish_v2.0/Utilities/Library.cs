using AdoptAFish_v2.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptAFish_v2.Utilities
{
    public class Library : ILibrary
    {
        public Library() { }

        public PlayerDetails SetUpPlayer()
        {
            var player = new PlayerDetails();
            //print out a request for the player to enter a new name
            Console.WriteLine("Welcome player! Please enter your name:");
            //get whatever the player typed in
            var playerInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(playerInput)) // check that the player entered something
            {
                // create an instance of Player
                player.PlayerName = playerInput;

            }
            else
            {
                Console.WriteLine("Application can not continue without a name for the player. Please enter your name:");
                playerInput = Console.ReadLine(); // wait for any keystroke
                if (!string.IsNullOrEmpty(playerInput))
                {
                    player.PlayerName = playerInput;
                }
                else
                {
                    Console.WriteLine("Application can not continue without a name for the player.");
                }
            }

            return player;
        }

        public void GenerateTank()
        { }

        public void GenerateFish()
        { }
    }
}
