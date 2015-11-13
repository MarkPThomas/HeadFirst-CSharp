using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMaker misterCoffee = new CoffeeMaker();
            Oven oldToasty = new Oven();

            // Method can take any class that inherits from appliance
            MonitorPower(misterCoffee);

            // Array can take any class that inherits from appliance
            Appliance[] kitchenWare = new Appliance[2];
            kitchenWare[0] = misterCoffee;
            kitchenWare[1] = oldToasty;

            // UPCAST: CoffeeMaker to Appliance
            // When you have an appliance reference, you can ONLY access 
            // the methods and properties that have to do with appliances.
            // You CAN'T use the CoffeeMaker methods and properties through 
            // an Appliance reference, even if you know it really is one.
            Appliance powerConsumer = new CoffeeMaker();
            powerConsumer.ConsumePower();

            // DOWNCAST: Appliance to CoffeeMaker
            // You can determine if the Appliance is a CoffeeMaker using `is`
            // If so, you can downcast it back to access the CoffeeMaker
            // properties & methods
            if (powerConsumer is CoffeeMaker)
            {
                CoffeeMaker javaJoe = powerConsumer as CoffeeMaker;
                javaJoe.MakeCoffee();

                // In an incorrect downcast, the object returned is null, so `Preheat` will not be called
                Oven foodWarmer = powerConsumer as Oven;
                if (foodWarmer != null)
                {
                    foodWarmer.Preheat();
                }
               
            }

            // Three different references that point to the same object can
            // acess different methods and properties, depending on the
            // reference's type.

            // Reference 1
            Oven misterToasty = new Oven();
            misterToasty.Preheat();

            // Reference 2
            ICooksFood cooker;
            if (misterToasty is ICooksFood)
            {
                cooker = misterToasty as ICooksFood;
                cooker.HeatUp();
            }

            // Reference 3
            if (misterToasty is Appliance)
            {
                powerConsumer = misterToasty;
                powerConsumer.ConsumePower();
            }
        }

        public static void MonitorPower(Appliance appliance)
        {
            // Code to add data to a household power consumption database
        }

        
    }
}
