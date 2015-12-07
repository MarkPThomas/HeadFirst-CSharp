using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTypes
{
    // delegate [method type] DelegateName ([method parameters]);
    // delegates call methods with matching signatures
    // method type can be void, string, etc. and only works with a delegate calling a matching type.
    // method parameters only works with a delegate calling matching parameters to form
    delegate string ConvertsIntToString(int i);

}
