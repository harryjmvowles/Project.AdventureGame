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
        public Dictionary<string, string> PointsOfInterest { get; set; }
        public Dictionary<string, string> Exits { get; set; }
        public Door RoomDoor { get; set; }

        //Used to create rooms with basic variables.
        public Room(string name, string description, List<string> items = null, Door door = null)
        {
            Name = name;
            Description = description;
            Items = items ?? new List<string>();
            PointsOfInterest = new Dictionary<string, string>();
            Exits = new Dictionary<string, string>();
            RoomDoor = door ?? new Door();
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
                //Display the room details
                Console.WriteLine("You enter a new room... it is clearly the " + Name);
                Console.WriteLine(Description);
                DisplayItems();
                DisplayPointsOfInterest();

                //The player has now been in this room
                BeenHere = true;
            }
            //If the player has been here before
            else
            {
                //Display a generic message
                Console.WriteLine("You are back in the " + Name);
                Console.WriteLine(Description);
                DisplayItems();
                DisplayPointsOfInterest();
            }
        }

        //Display the items in the room
        public void DisplayItems()
        {
            if (Items.Count > 0)
            {
                Console.WriteLine("Items in the room:");
                foreach (string item in Items)
                {
                    Console.WriteLine("- " + item);
                }
            }
        }

        //Display points of interest (like Desk, Bookshelf, etc)
        public void DisplayPointsOfInterest()
        {
            if (PointsOfInterest.Count > 0)
            {
                Console.WriteLine("Points of interest in the room:");
                foreach (string point in PointsOfInterest.Keys)
                {
                    Console.WriteLine("- " + point);
                }
            }
        }

        //Process actions for the room
        public void ProcessRoomActions(Player currentPlayer)
        {
            string command;
            do
            {
                //Show available actions
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. View inventory");
                Console.WriteLine("2. Interact with a point of interest");
                Console.WriteLine("3. Pick up an item");
                Console.WriteLine("4. Go to the door");
                Console.WriteLine("5. Exit the room");

                //Read player input
                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        currentPlayer.ViewInventory();  //Show inventory
                        break;
                    case "2":
                        Console.WriteLine("Which point of interest would you like to interact with?");
                        string poi = Console.ReadLine();
                        InteractWithPointOfInterest(poi);  //Interact with a point of interest
                        break;
                    case "3":
                        Console.WriteLine("Which item would you like to pick up?");
                        string item = Console.ReadLine();
                        PickUpItem(item, currentPlayer);  //Pick up an item
                        break;
                    case "4":
                        RoomDoor.CheckDoorStatus();  //Check door status (locked/unlocked)
                        break;
                    case "5":
                        Console.WriteLine("Exiting the room...");
                        break;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            } while (command != "5");  //Exit the room loop when the player chooses to leave
        }

        //Interact with points of interest (stub for interaction logic)
        private void InteractWithPointOfInterest(string poi)
        {
            if (PointsOfInterest.ContainsKey(poi))
            {
                Console.WriteLine($"You interact with the {poi}. {PointsOfInterest[poi]}");
            }
            else
            {
                Console.WriteLine("That point of interest doesn't exist in this room.");
            }
        }

        //Pick up an item from the room
        private void PickUpItem(string item, Player currentPlayer)
        {
            if (Items.Contains(item))
            {
                Console.WriteLine($"You pick up the {item}.");
                Items.Remove(item);
                currentPlayer.AddToInventory(item); 
            }
            else
            {
                Console.WriteLine("That item is not in the room.");
            }
        }
    }

