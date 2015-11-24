using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeehiveManagement
{
    class HoneyDeliverySystem
    {
        int honeyLevel = 0;
        public int HoneyLevel { get { return honeyLevel; } set {honeyLevel = value; } }
        List<Egg> Eggs = new List<Egg>();


        public void FeedHOneyToEggs()
        {
            if (honeyLevel == 0)
            {
                throw new OutOfHoneyException("The hive is out of honey.");
            }
            else
            {
                MessageBox.Show("This code will run if the exception is not thrown.");
                foreach (Egg egg in Eggs)
                {
                   // Egg handling
                }
            }
        }
    }
}
