using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // A delegate variable points to a method with a matching signature, instead of a value or object
            ConvertsIntToString someMethod = new ConvertsIntToString(HiThere);

            // You can set someMethod just like any other variable. 
            // When you call it like a method, it calls whatever method it happens to point to.
            string message = someMethod(5);
            Console.WriteLine(message);
            Console.ReadKey();
        }

        private static string HiThere(int i)
        {
            return "Hi there! #" + (i * 100);
        }
    }
}
