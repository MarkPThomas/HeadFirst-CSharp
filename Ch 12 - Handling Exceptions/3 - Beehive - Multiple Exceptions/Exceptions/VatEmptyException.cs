using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagement
{
    class VatEmptyException : Exception
    {
        public VatEmptyException(string message) : base(message) { }
    }
}
