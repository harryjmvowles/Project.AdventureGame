using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Dictionary<string, PointOfInterest> PointsOfInterest { get; set; }
        public Dictionary<string, string> Exits { get; set; }
        public Door RoomDoor { get; set; }

        //Used to create rooms with basic variables, including points of interest
        public Room(string name, string description, List<string> items = null, Dictionary<string, PointOfInterest> pointsOfInterest = null, Door door = null)
        {
            Name = name;
            Description = description;
            Items = items ?? new List<string>();  //Default empty list if no items passed
            PointsOfInterest = pointsOfInterest ?? new Dictionary<string, PointOfInterest>();  //Default empty dictionary if no points of interest passed
            Exits = new Dictionary<string, string>();  //Default empty dictionary for exits
            RoomDoor = door ?? new Door();  //Default a new door if no door passed
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
                Console.WriteLine("You enter a new room... it is clearly " + Name);
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

            Console.WriteLine("");
            Console.WriteLine("             ----                ");
            Console.WriteLine("");
            ProcessRoomActions(Program.currentPlayer);
        }

        //Display the items in the room
        public void DisplayItems()
        {
            //Check if there is exactly one item in the list
            if (Items.Count == 1)
            {
                //If that item is empty, display "Items: N/A"
                if (string.IsNullOrEmpty(Items[0]))
                {
                    Console.WriteLine("Items: N/A");
                }
                else
                {
                    Console.WriteLine("Item in the room: " + Items[0]);
                }
            }
            //If there are more than one item
            else if (Items.Count > 1)
            {
                Console.WriteLine("Items in the room:");
                foreach (string item in Items)
                {
                    Console.WriteLine("- " + item);
                }
            }
            //If there are no items in the room
            else
            {
                Console.WriteLine("No items in the room.");
            }
        }

        //Display points of interest (like Desk, Bookshelf, etc)
        public void DisplayPointsOfInterest()
        {
            if (PointsOfInterest.Count > 0)
            {
                Console.WriteLine("Points of interest in the room:");
                foreach (var poi in PointsOfInterest)
                {
                    Console.WriteLine($"- {poi.Key}: {poi.Value.Description}");
                }
            }
        }

        //Process actions for the room
        public void ProcessRoomActions(Player currentPlayer)
        {
            string command;
            do
            {
                //Show available actions + reshow description
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. View Room description again");
                Console.WriteLine("2. View inventory/Health Status");
                Console.WriteLine("3. Interact with a point of interest");
                Console.WriteLine("4. Pick up an item");
                Console.WriteLine("5. Go to the door");
                Console.WriteLine("6. Exit the room");

                //Read player input
                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(Description);  //Show room description
                        DisplayItems();
                        DisplayPointsOfInterest();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        currentPlayer.ViewInventory();  //Show inventory
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        DisplayPointsOfInterest();
                        Console.WriteLine("Which point of interest would you like to interact with?");
                        string poi = Console.ReadLine();
                        InteractWithPointOfInterest(poi, currentPlayer);  //Interact with a point of interest
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        Console.WriteLine("Which item would you like to pick up?");
                        string item = Console.ReadLine();
                        PickUpItem(item, currentPlayer);  //Pick up an item
                        break;
                    case "5":
                        Console.WriteLine("This feature has not been added yet.");  //Check door status (locked/unlocked) Not Implemented yet!
                        break;
                    case "6":
                        Console.WriteLine("This feature has not been added yet."); //Exit the room Not Implemented yet!
                        break;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            } while (command != "6");  //Exit the room loop when the player chooses to leave
        }

        //Interact with points of interest
        private void InteractWithPointOfInterest(string poiName, Player currentPlayer)
        {
            if (PointsOfInterest.ContainsKey(poiName))
            {
                PointOfInterest point = PointsOfInterest[poiName];
                Console.WriteLine($"You interact with the {poiName}. {point.Description}");
                Console.WriteLine("Items here:");
                foreach (var item in point.Items)
                {
                    Console.WriteLine("- " + item);
                }

                //Option to pick up an item from this point of interest
                Console.WriteLine("Would you like to pick up an item from here? (yes/no)");
                string choice = Console.ReadLine().ToLower();
                if (choice == "yes")
                {
                    Console.WriteLine("Which item would you like to pick up?");
                    string itemToPick = Console.ReadLine();

                    if (point.Items.Contains(itemToPick))
                    {
                        Console.WriteLine($"You pick up the {itemToPick}.");
                        point.RemoveItem(itemToPick);  //Remove item from the point of interest
                        currentPlayer.AddToInventory(itemToPick);  //Add the item to the player's inventory
                    }
                    else
                    {
                        Console.WriteLine("That item is not available at this point of interest.");
                    }
                }
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
                if (item == "")
                    Console.WriteLine("That item does not Exist.");
                else
                    Console.WriteLine($"You pick up the {item}.");
                    Items.Remove(item);
                    currentPlayer.AddToInventory(item);
            }

            else
            {
                Console.WriteLine("That item is not in the room.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

}