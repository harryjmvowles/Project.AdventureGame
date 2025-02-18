using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    class Program
    {
        public static Player currentPlayer = new Player();
        static void Main(string[] args)
        {
            start();
        }

        static void start()
        {
            Console.WriteLine("|| THE DUNGEON ||");
            Console.WriteLine("Hello Adventurer, Brave enough to enter The Dungeon i see...");
            Console.WriteLine("What is your name?: ");
            currentPlayer.name = Console.ReadLine();

            while (currentPlayer.name == "")
            {
                Console.WriteLine("You must enter a name!");
                currentPlayer.name = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine($"Well GoodLuck {currentPlayer.name}! Take these.... You will need them.");
            Console.WriteLine(" [+2 Potions] " +
                "Press Any Key to continue....");
            currentPlayer.potions += 2;
            Console.ReadKey();
            Console.Clear();
        
            Console.WriteLine("The mysterious man at the entrance of The Dungeon suddenly disappeared, leaving you to face the tall, rusted metal door.");
            Console.WriteLine("You slowly push the door open, creaking and grating of the metal echoing through the many chambers as you enter.");
            Console.WriteLine("The door slams behind you, a sort of magic sealing you within.");
            Console.WriteLine(" You are now trapped in The Dungeon.... How will you escape?");



        }
    }
}