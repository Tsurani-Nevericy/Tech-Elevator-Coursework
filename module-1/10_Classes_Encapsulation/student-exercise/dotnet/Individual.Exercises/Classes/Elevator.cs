using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Elevator
    {
        public int CurrentLevel { get; private set; }
        public int NumberOfLevels { get; }
        public bool DoorIsOpen { get; private set; }
        public Elevator(int TotalNumberOfFloors)
        {
            CurrentLevel = 1;
            NumberOfLevels = TotalNumberOfFloors;
        }

        public void OpenDoor()
        {
            if (!DoorIsOpen)
            {
                DoorIsOpen = true;
            }
        }
        public void CloseDoor()
        {
            if (DoorIsOpen)
            {
                DoorIsOpen = false;
            }
        }
        public void GoUp(int desiredFloor)
        {
            if (CurrentLevel < NumberOfLevels && !DoorIsOpen)
            {
                CurrentLevel = desiredFloor;
            }
        }
        public void GoDown(int desiredFloor)
        {
            if (CurrentLevel > 1 && !DoorIsOpen)
            {
                CurrentLevel = desiredFloor;
            }
        }
    }

}
