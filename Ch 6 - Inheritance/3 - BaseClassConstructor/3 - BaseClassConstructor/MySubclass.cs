﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseClassConstructor
{
    class MySubclass : MyBaseClass
    {
        public MySubclass(string baseClassNeedsThis, int anotherValue)
            : base(baseClassNeedsThis)
        {
            MessageBox.Show("This is a subclass: " + baseClassNeedsThis + " and " + anotherValue);
        }
    }
}
