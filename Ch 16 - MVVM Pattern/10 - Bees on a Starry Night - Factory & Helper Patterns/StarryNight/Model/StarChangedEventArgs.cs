﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StarryNight.Model
{
    class StarChangedEventArgs : EventArgs
    {
        public Star StarThatChanged { get; private set; }
        public bool Removed { get; private set; }

        public StarChangedEventArgs(Star starThatChanged, bool removed)
        {
            StarThatChanged = starThatChanged;
            Removed = removed;
        }
    }
}
