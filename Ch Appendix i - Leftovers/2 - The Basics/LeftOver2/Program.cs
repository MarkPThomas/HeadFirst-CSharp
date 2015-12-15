using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftOver2
{
    class Program
    {
        static void Main(string[] args)
        {
            Guy bob = new Guy("Bob", 43, 100);
            Guy joe = new Guy("Joe", 41, 100);
            Random random = new Random();

            while (true)
            {
                int amountToGive = random.Next(20);

                if (amountToGive < 10)
                {
                    // This causes the program to jump over the rest of the iteration and back to the top of the loop.
                    continue;
                }

                if (joe.ReceiveCash(bob.GiveCash(amountToGive)) == 0)
                {
                    // This terminates the loop early.
                    break;
                }

                Console.WriteLine("Bob gave Joe {0} bucks, Joe has {1} bucks, Bob has {2} bucks",
                    amountToGive, joe.Cash, bob.Cash);
            }
            Console.WriteLine("Bob's left with {0} bucks", bob.Cash);

            // Conditional Operator: is an if/then/else collapsed into a single expression.
            // [boolean test] ? [statement to execute if true] : [statement to execute if false]
            Console.WriteLine("Bob {0} more cash than Joe",
                                bob.Cash > joe.Cash ? "has" : "does not have");

            // Coalescing Operator (??): Checks if a value is null and either returns the value, or a backup value.
            // [value to test] ?? [value to return if it is null]
            bob = null;
            Console.WriteLine("Result of ?? is '{0}'", bob ?? joe);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i > 3)
                    {
                        goto afterLoop;
                    }
                    Console.WriteLine("i = {0}, j = {1}", i, j);
                }
            }
            // [This is a label] : [This is code executed after the label]
            afterLoop: Console.WriteLine("GoTo: afterLoop");


            int a;
            // This sets a to 3*5, then sets b to a.
            int b = (a = 3 * 5);
            Console.WriteLine("a = {0}; b = {1};", a, b);

            // If ++ is before a variable, it increments the variable first, then executes the rest of the statement.
            // e.g.  a = (b + 1) * 10
            a = ++b * 10;
            Console.WriteLine("a = {0}; b = {1};", a, b);

            // If ++ is after a variable, the statement executes first, and then the variable is incremented.
            // e.g. a = (b * 10) + 1
            a = b++ * 10;
            Console.WriteLine("a = {0}; b = {1};", a, b);

            // Short Circuit boolean logic: 
            int x = 0;
            int y = 10;
            int z = 20;

            // || (or else) only evaluates the next test if the first one is false.
            if ((y < z) || (y / x == 4))
            {
                Console.WriteLine("this line printed because || short-circuited");
            }
            
            // && (and also) only evaluates the next test if the first one is true. 
            if ((y > z) && (y / x == 4))
            {
                Console.WriteLine("this line will NEVER print because && short-circuited");
            }

            // Convert 217 to base 2 (binary) as a string.
            string binaryValue = Convert.ToString(217, 2);

            // Convert binary (base 2) string to an integer.
            int intValue = Convert.ToInt32(binaryValue, 2);
            Console.WriteLine("Binary {0} is integer {1}", binaryValue, intValue);

            // Bitwise Operators:
            // These are built-in on all integral numeric types, enums, and booleans.
            int val1 = Convert.ToInt32("100000001", 2);
            int val2 = Convert.ToInt32("001010100", 2);

            // (or) does not short-circuit. Both are evaluated.
            int or = val1 | val2;

            // (and) does not short-circuit. Both are evaluated.
            int and = val1 & val2;

            // (exclusive or) can only be true if only ONE of the tests is true. False if both tests are false OR true.
            int xor = val1 ^ val2;

            // (bitwise complement)(logical negation) is an analog to ! for booleans
            int not = ~val2;


            // Pad Leading Characters:
            Console.WriteLine("val1: {0}", Convert.ToString(val1, 2));
            Console.WriteLine("val2: {0}", Convert.ToString(val2, 2).PadLeft(9, '0'));
            Console.WriteLine("  or: {0}", Convert.ToString(or, 2).PadLeft(9, '0'));
            Console.WriteLine(" and: {0}", Convert.ToString(and, 2).PadLeft(9, '0'));
            Console.WriteLine(" xor: {0}", Convert.ToString(xor, 2).PadLeft(9, '0'));
            Console.WriteLine(" not: {0}", Convert.ToString(not, 2).PadLeft(9, '0'));
            // Notice that 'not' returns the 32-bit complement of 'val1'

            // Shifting Bits:
            // << and >> operators shift bits left and right.
            // >>= or &= are just like += and *=
            int bits = Convert.ToInt32("11", 2);
            for (int i = 0; i < 5; i++)
            {
                bits <<= 2;
                Console.WriteLine(Convert.ToString(bits, 2).PadLeft(12, '0'));
            }
            for (int i = 0; i < 5; i++)
            {
                bits >>= 2;
                Console.WriteLine(Convert.ToString(bits, 2).PadLeft(12, '0'));
            }

            // You can instantiate a new object and call a method on it without using a variable reference.
            Console.WriteLine(new Guy("Harry", 47, 376).ToString());

            // Used instead of '+' for more efficient string concatenation since '+' adds a new object to the heap each time it is executed.
            // StringBuilder is used when many iterations are done, or if you don't know how many iterations will be performed.
            // StringBuilder is less efficient than '+' for fewer loops like this example because memory is not pre-allocated.
            StringBuilder stringBuilder = new StringBuilder("Hi ");
            stringBuilder.Append("there, ");
            // This appends a formatted string.
            stringBuilder.AppendFormat("{0} year old guy named {1}. ", joe.Age, joe.Name);
            // This appends a line with a line break at the end.
            stringBuilder.AppendLine("Nice weather we're having.");
            // Call this to get the final result.
            Console.WriteLine(stringBuilder.ToString());

            Console.ReadKey();
        }
    }
}
