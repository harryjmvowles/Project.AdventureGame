using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    public class Door
    {
        //Door state
        public bool IsLocked { get; set; }
        public string DoorDescription { get; set; }

        //Constructor to initialize the door with a description and its lock state
        public Door(string description = "A wooden door", bool isLocked = false)
        {
            DoorDescription = description;
            IsLocked = isLocked;
        }

        //Check the status of the door (locked/unlocked)
        public void CheckDoorStatus()
        {
            if (IsLocked)
            {
                Console.WriteLine("The door is locked.");
            }
            else
            {
                Console.WriteLine("The door is unlocked.");
            }
        }

        //Unlock the door (if locked)
        public void Unlock()
        {
            if (IsLocked)
            {
                IsLocked = false;
                Console.WriteLine("You have unlocked the door.");
            }
            else
            {
                Console.WriteLine("The door is already unlocked.");
            }
        }

        //Lock the door (if unlocked)
        public void Lock()
        {
            if (!IsLocked)
            {
                IsLocked = true;
                Console.WriteLine("You have locked the door.");
            }
            else
            {
                Console.WriteLine("The door is already locked.");
            }
        }
    }
}
