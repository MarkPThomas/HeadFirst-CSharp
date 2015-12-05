using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject;

namespace MyExtensions
{
    // It's a good idea to keep all of your extensions in a different namespace than the rest of your code.
    // That way, you won't have problem finding them for use in other programs.
    public static class HumanExtensions
    {
        // Make sure the method is public so that it is accessible to other namespaces
        public static bool IsDistressCall(this string s)
        {
            if (s.Contains("Help!"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
