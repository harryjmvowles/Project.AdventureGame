using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Program
    {
        //creates new player object (The Users Player).
        public static Player currentPlayer = new Player();
        static void Main(string[] args)
        {
            //Calls Start of Game
            start();
        }

        //Start of Game
        
        static void start()
        {
            //Name Enter
            Console.WriteLine("|| THE DUNGEON ||");
            Console.WriteLine("Hello Adventurer, Brave enough to enter The Dungeon i see...");
            Console.WriteLine("What is your name?: ");
            currentPlayer.name = Console.ReadLine();
            
            //Name Check
            while (currentPlayer.name == "")
            {
                Console.WriteLine("You must enter a name!");
                currentPlayer.name = Console.ReadLine();
            }
            Console.Clear();

            //introduces item system (via potions)
            Console.WriteLine($"Well GoodLuck {currentPlayer.name}! Take these.... You will need them.");
            Console.WriteLine(" [+2 Potions] " +
                "Press Any Key to continue....");
            currentPlayer.potions += 2;
            Console.ReadKey();
            Console.Clear();

            //World Building... Start of Dungeon.
            Console.WriteLine("The mysterious man at the entrance of The Dungeon suddenly disappeared, leaving you to face the tall, rusted metal door.");
            Console.WriteLine("You slowly push the door open, creaking and grating of the metal echoing through the many chambers as you enter.");
            Console.WriteLine("The door slams behind you, a sort of magic sealing you within.");
            Console.WriteLine("You are now trapped in The Dungeon.... How will you escape?");
            Console.WriteLine("Press Any Key to continue....");
            Console.ReadKey();
            Console.Clear();

            //Initialize RoomManager to access predefined rooms
            RoomManager roomManager = new RoomManager();

            //Retrieve the 'Lost Hall' room from the RoomManager
            Room lostHall = roomManager.GetRoom("The Lost Hall");

            //Now let the player enter the Lost Hall room
            if (lostHall != null)
            {
                lostHall.Enter();
            }
            else
            {
                Console.WriteLine("The Lost Hall room could not be found.");
            }


        }
    }
}
