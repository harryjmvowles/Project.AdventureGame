using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    //Creates Player Class
    class Player
    {
        //Basic information for Player with default values.
        public string name;
        public int health = 100;
        public int attack = 10;
        public int defense = 5;
        public int gold = 0;
        public int potions = 0;
        public int keys = 0;
        public int level = 1;
        public int experience = 0;
        public int experienceToNextLevel = 100;
        public List<string> Inventory { get; set; }

        //view player's inventory
        public void ViewInventory()
        {
            Console.WriteLine("Your Inventory:");
            foreach (string item in Inventory)
            {
                Console.WriteLine("- " + item);
            }
        }

        //Add item to player's inventory
        public void AddToInventory(string item)
        {
            Inventory.Add(item);
        }
    }
}
