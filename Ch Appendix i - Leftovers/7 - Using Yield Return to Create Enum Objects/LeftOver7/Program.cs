using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftOver7
{
    class Program
    {
        static void Main(string[] args)
        {
            // The following manually implements IEnumerable in order to create a new enumerator.
            Console.WriteLine("SportCollection contents:");
            SportCollection sportCollection = new SportCollection();
            foreach (Sport sport in sportCollection)
            {
                Console.WriteLine(sport.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("SportCollection contents:");
            SportCollectionYieldReturn sportCollectionYieldReturn = new SportCollectionYieldReturn();
            foreach (Sport sport in sportCollectionYieldReturn)
            {
                Console.WriteLine(sport.ToString());
            }

            Console.WriteLine();
            IEnumerable<string> names = NameEnumerator(); // Put a breakpoint here
            foreach (string name in names)
                Console.WriteLine(name);

            // Use the Guy's indexer 
            Console.WriteLine("Adding two guys and modifying one guy");
            GuyCollection guyCollection = new GuyCollection();
            
            // Update one guy's age
            guyCollection["Bob"] = guyCollection["Joe"] + 3;

            // Add two more guys
            guyCollection["Bill"] = 57;
            guyCollection["Harry"] = 31;

            foreach (Guy guy in guyCollection)
            {
                Console.WriteLine(guy.ToString());
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Demonstrates 'yield return' in a way that is easier to step through in the debugger.
        /// </summary>
        /// <returns></returns>
        static IEnumerable<string> NameEnumerator()
        {
            yield return "Bob";     // The method exits after this statement ...
            yield return "Harry";   // ... and resumes here the next time through.
            yield return "Joe";
            yield return "Frank";
        }
    }
}
