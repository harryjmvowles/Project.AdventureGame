using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    //Creates Room Class
    public class Room
        
    {
        //variables for Room Class
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Items { get; set; }
        public bool BeenHere = false;

        //Used to create rooms with basic variables.
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<string>();
            BeenHere = false;
        }

        //Add an item to the room
        public void AddItem(string item)
        {
            Items.Add(item);
        }

        //Remove an item from the room
        public void RemoveItem(string item)
        {
            Items.Remove(item);
        }

        //When the player enters the room
        public void Enter()
        {
            //If the player has not been here before
            if (!BeenHere)
            {
                //Display the room description
                Console.WriteLine("You enter a new room... it is clearly the " + Name);
                Console.WriteLine(Description);
                //If there are items in the room
                if (Items.Count > 0)
                {
                    //Display the items in the room
                    Console.WriteLine("You see the following items:");
                    foreach (string item in Items)
                    {
                        Console.WriteLine(item);
                    }
                }
                //The player has now been in this room
                BeenHere = true;
            }
            //If the player has been here before
            else
            {
                //Display a generic message
                Console.WriteLine("You are back in the " + Name);
                Console.WriteLine(Description);
            }
        }

    }

