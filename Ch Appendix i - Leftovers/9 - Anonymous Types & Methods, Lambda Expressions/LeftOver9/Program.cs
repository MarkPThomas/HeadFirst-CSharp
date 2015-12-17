using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftOver9
{
    class Program
    {
        delegate void MyIntAndString(int i, string s);
        delegate int CombineTwoInts(int x, int y);

        static void Main(string[] args)
        {
            // Anonymous Type
            // Create an anonymous type that looks a lot like a guy:
            var anonymousGuy = new { Name = "Bob", Age = 43, Cash = 137 };

            Console.WriteLine("{0} is {1} years old and has {2} bucks.",
                anonymousGuy.Name, anonymousGuy.Age, anonymousGuy.Cash);
            Console.WriteLine();
            Console.WriteLine(anonymousGuy.ToString());

            Console.WriteLine();

            // Anonymous Method
            // Here's an anonymous method that writes an int and a string to the console.
            // Its declaration matches our MyIntAndString delegate (defined above), so
            //      we can assign it to a variable of type MyIntAndString.
            MyIntAndString printThem = delegate (int i, string s)
                                            { Console.WriteLine("{0} - {1}", i, s); };
            printThem(123, "four five six");
            Console.WriteLine();

            MyIntAndString contains = delegate (int i, string s)
                                            { Console.WriteLine(s.Contains(i.ToString())); };
            // False
            contains(123, "four five six");
            Console.WriteLine();

            // True
            contains(123, "four 123 five six");
            Console.WriteLine();

            // You can dynamically invoke a method using Delegate.DynamicInvoke(),
            //      passing the parameters to the method as an array of objects.
            Delegate d = contains;
            // True
            d.DynamicInvoke(new object[] { 123, "four 123 five six" });
            Console.WriteLine();

            // Lambda Expressions
            // (a,b) => {return a + b; }
            // Reads as "a and b goes to a plus b"

            CombineTwoInts adder = (a, b) => { return a + b; };
            Console.WriteLine(adder(3, 5));
            Console.WriteLine();

            CombineTwoInts multiplier = (int a, int b) => { return a * b; };
            Console.WriteLine(multiplier(3, 5));
            Console.WriteLine();

            // Lambda expression combined with LINQ
            var greaterThan3 = new List<int> { 1, 2, 3, 4, 5, 6 }.Where(x => x > 3);
            foreach (int i in greaterThan3)
            {
                Console.WriteLine("{0} ", i);
            }
            Console.WriteLine();

            // Another lambda expression using a non-anonymous type
            List<int> newList = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var lessThan3 = newList.Where(x => x < 3);
            foreach (int i in lessThan3)
            {
                Console.WriteLine("{0} ", i);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
