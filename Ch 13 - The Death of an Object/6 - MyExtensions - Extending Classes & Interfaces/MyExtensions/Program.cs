using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExtensions;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Clones are wreaking havoc at the factory. Help!";

            if (message.IsDistressCall())
            {
                // Go help them out!
            }

        }
    }
}
