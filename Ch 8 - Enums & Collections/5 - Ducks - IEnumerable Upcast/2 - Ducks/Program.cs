using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Duck> ducks = new List<Duck>(){
                new Duck() {Kind = KindOfDuck.Mallard, Size = 17, Name="Milroy"},
                new Duck() {Kind = KindOfDuck.Muscovy, Size = 18, Name="Donald"},
                new Duck() {Kind = KindOfDuck.Decoy, Size = 14, Name="Daffy"},
                new Duck() {Kind = KindOfDuck.Mallard, Size = 11, Name="Loony"},
                new Duck() {Kind = KindOfDuck.Muscovy, Size = 14, Name="Quack"},
                new Duck() {Kind = KindOfDuck.Decoy, Size = 13, Name="Quackers"}
            };

            Console.WriteLine("List of ducks: ");
            foreach (Duck duck in ducks)
            {
                Console.WriteLine(duck);
            }

            IEnumerable<Bird> upcastDucks = ducks;
            Console.WriteLine("\n\rList of ducks from an upcast list as a bird: ");
            foreach (Bird bird in upcastDucks)
            {
                Console.WriteLine(bird);
            }

            Console.WriteLine("\n\rList of ducks from the ducks list as a bird: ");
            foreach (Bird bird in ducks)
            {
                Console.WriteLine(bird);
            }

            List<Bird> birds = new List<Bird>();
            birds.Add(new Bird(){ Name = "Feathers" });
            birds.AddRange(ducks);
            birds.Add(new Penguin(){ Name = "George" });

            Console.WriteLine("\n\rList of birds: ");
            foreach (Bird bird in birds)
            {
                Console.WriteLine(bird);
            }

            List<Object> mismatchedBirds = new List<Object>();
            mismatchedBirds.AddRange(birds);
            mismatchedBirds.Add(new Shoe()
                                    {
                                        Color = "brown",
                                        Style  = Style.Flipflops
                                    });

            Console.WriteLine("\n\rList of all items in the mismatched list:");
            foreach (Object item in mismatchedBirds)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        public static void PrintDucks(List<Duck> ducks)
        {
            foreach (Duck duck in ducks)
            {
                Console.WriteLine(duck);
            }
            Console.WriteLine("End of ducks!\n\r");
        }



    }
}
