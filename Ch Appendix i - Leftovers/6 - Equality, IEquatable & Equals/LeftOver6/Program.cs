using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftOver6
{
    class Program
    {
        static void Main(string[] args)
        {
            Guy joe1 = new Guy("Joe", 37, 100);

            // True
            Guy joe2 = joe1;
            Console.WriteLine(ReferenceEquals(joe1, joe2));
            Console.WriteLine(joe1.Equals(joe2));
            Console.WriteLine(ReferenceEquals(null, null));

            // False
            joe2 = new Guy("Joe", 37, 100);
            Console.WriteLine(ReferenceEquals(joe1, joe2));
            Console.WriteLine(joe1.Equals(joe2));

            // Now that Equals() and GetHashCode() are implemented in EquatableGuy, the following will work:
            List<Guy> guys = new List<Guy>()
            {
                new Guy("Bob", 42, 125),
                new EquatableGuy(joe1.Name, joe1.Age, joe1.Cash),
                new Guy("ed", 39, 95)
            };

            // True
            Console.WriteLine(guys.Contains(joe1));

            // False
            Console.WriteLine(joe1 == joe2);

            // Object comparison with overwritten equals operators
            joe1 = new EquatableGuyWithOverload(joe1.Name, joe1.Age, joe1.Cash);
            joe2 = new EquatableGuyWithOverload(joe1.Name, joe1.Age, joe1.Cash);

            // Below does not work as expected beause its calling Guy's == & != operators
            // False
            Console.WriteLine(joe1 == joe2);
            // True
            Console.WriteLine(joe1 != joe2);

            // Cast to EquatableGuyWithOverload to call the correct == & !=
            // True
            Console.WriteLine((EquatableGuyWithOverload)joe1 == (EquatableGuyWithOverload)joe2);
            // False
            Console.WriteLine((EquatableGuyWithOverload)joe1 != (EquatableGuyWithOverload)joe2);

            joe2.ReceiveCash(25);

            // False
            Console.WriteLine((EquatableGuyWithOverload)joe1 == (EquatableGuyWithOverload)joe2);
            // True
            Console.WriteLine((EquatableGuyWithOverload)joe1 != (EquatableGuyWithOverload)joe2);

            // Now to make it work without casting
            EquatableGuyWithOverload joe3 = new EquatableGuyWithOverload(joe1.Name, joe1.Age, joe1.Cash);
            EquatableGuyWithOverload joe4 = new EquatableGuyWithOverload(joe1.Name, joe1.Age, joe1.Cash);

            // True
            Console.WriteLine(joe3 == joe4);
            // False
            Console.WriteLine(joe3 != joe4);

            Console.ReadKey();
        }
    }
}
