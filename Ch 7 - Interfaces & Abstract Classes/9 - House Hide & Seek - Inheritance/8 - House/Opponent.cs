using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Opponent
    {
        private Location myLocation;
        private Random random;

        public Opponent(Location startingLocation)
        {
            myLocation = startingLocation;
            random = new Random();
        }

        public void Move()
        {
            bool hidden = false;

            while (!hidden)
            {
                if (myLocation is IHasExteriorDoor)
                {
                    if (random.Next(2) == 1)
                    {
                        IHasExteriorDoor nextLocation = myLocation as IHasExteriorDoor;
                        myLocation = nextLocation.DoorLocation;
                    }
                }

                myLocation = myLocation.Exits[random.Next(myLocation.Exits.Length)];
                if (myLocation is IHidingPlace)
                    hidden = true;
            }            
        }
        
        public bool Check(Location location)
        {
            if (location.Name == myLocation.Name)
                return true;
            else
                return false;
        }

       
    }
}
