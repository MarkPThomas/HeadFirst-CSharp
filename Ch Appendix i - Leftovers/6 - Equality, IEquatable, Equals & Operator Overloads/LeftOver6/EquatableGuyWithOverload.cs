using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftOver6
{
    /// <summary>
    /// A guy that knows how to compare itself with other guys.
    /// </summary>
    class EquatableGuyWithOverload : EquatableGuy
    {
        public EquatableGuyWithOverload(string name, int age, int cash)
            : base(name, age, cash)
        { }

        public static bool operator == (EquatableGuyWithOverload left,
                                        EquatableGuyWithOverload right)
        {
            // Comparison to null now needs to be done this way to avoid a StackOverflowException
            if (ReferenceEquals(left, null))
            {
                return false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        public static bool operator != (EquatableGuyWithOverload left,
                                        EquatableGuyWithOverload right)
        {
            return !(left == right);
        }

        // The methods below must also be overwritten
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
