using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//An assembly is the unit of deployment and identity for managed code programs.Although assemblies can span one or more files, typically an assembly maps one-to-one with a DLL.
//  Therefore, this section describes only DLL naming conventions, which then can be mapped to assembly naming conventions.

//✓ DO choose names for your assembly DLLs that suggest large chunks of functionality, such as System.Data.
//Assembly and DLL names don’t have to correspond to namespace names, but it is reasonable to follow the namespace name when naming assemblies.
//  A good rule of thumb is to name the DLL based on the common prefix of the assemblies contained in the assembly. 
//  For example, an assembly with two namespaces, MyCompany.MyTechnology.FirstFeature and MyCompany.MyTechnology.SecondFeature, could be called MyCompany.MyTechnology.dll.

//✓ CONSIDER naming DLLs according to the following pattern:
//<Company>.<Component>.dll
//where <Component> contains one or more dot-separated clauses. For example:
//Litware.Controls.dll.
namespace HeadFirst.CSharp.Leftover3
{
    /// <summary>
    /// A guy wth a name, age and a wallet full of bucks
    /// </summary>
    public class Guy
    {
        /* Readonly backing fields can only be set when the object is initialized
         * (in their declarations or in the constructor)
         */
        
        /// <summary>
        /// Read-only backing field for the Name property.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The name of the guy.
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Read-only backing field for the Age property.
        /// </summary>
        private readonly int age;

        /// <summary>
        /// The guy's age.
        /// </summary>
        public int Age { get { return age; } }

        /*
         * Cash is not readonly becayse it might change during the life of the Guy
         */

        /// <summary>
        /// The number of bucks the guy has.
        /// </summary>
        public int Cash { get; private set; }

        /// <summary>
        /// The constructor sets the name, age and cash.
        /// </summary>
        /// <param name="name">The name of the guy.</param>
        /// <param name="age">The guy's age.</param>
        /// <param name="cash">The amount of cash the guy starts with.</param>
        public Guy(string name, int age, int cash)
        {
            this.name = name;
            this.age = age;
            Cash = cash;
        }


        public override string ToString()
        {
            return string.Format("{0} is {1} years old and has {2} bucks", Name, Age, Cash);
        }

        /// <summary>
        /// Give cash from my wallet.
        /// </summary>
        /// <param name="amount">The amount of cash to give.</param>
        /// <returns>The amount of cash I gave, or 0 if I don't have enough cash.</returns>
        public int GiveCash(int amount)
        {
            if (amount <= Cash && amount > 0)
            {
                Cash -= amount;
                return amount;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Receive some cash into my wallet.
        /// </summary>
        /// <param name="amount">Amount to receive.</param>
        /// <returns>The amount of cash received, or 0 if no cash was received.</returns>
        public int ReceiveCash(int amount)
        {
            if (amount > 0)
            {
                Cash += amount;
                return amount;
            }
            Console.WriteLine("{0} says: {1} isn't an amount I'll take", Name, amount);
            return 0;
        }
    }
}
