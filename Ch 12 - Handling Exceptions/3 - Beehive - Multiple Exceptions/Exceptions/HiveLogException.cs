using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagement
{
    class HiveLogException : Exception
    {
        public HiveLogException(string message) : base(message) { }
    }
}
