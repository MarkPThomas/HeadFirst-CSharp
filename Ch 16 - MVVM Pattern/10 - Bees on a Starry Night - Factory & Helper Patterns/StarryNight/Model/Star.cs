using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StarryNight.Model
{
    class Star
    {
        public Point Location { get; set; }

        public Star(Point location)
        {
            Location = location;
            // Once the program is working, add a Boolean Rotating property to the class and use it to make some stars slowly spin
        }
    }
}
