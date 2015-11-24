using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagement
{
    class OutOfHoneyException : Exception
    {
        public OutOfHoneyException(string message) : base(message) { }
    }
}
