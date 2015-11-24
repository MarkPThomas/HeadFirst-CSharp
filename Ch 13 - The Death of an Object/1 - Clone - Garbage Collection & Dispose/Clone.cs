using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloneGarbage
{
    class Clone : IDisposable
    {
        public int Id { get; private set; }

        public Clone(int Id)
        {
            this.Id = Id;
        }

        // Triggered when called directly, or automatically from 'Using' statements.
        public void Dispose()
        {
            MessageBox.Show("I've been disposed!",
                            "Clone #" + Id + " says...");
        }

        // Object finalizer. Triggered when garbage collection occurs.
        ~Clone()
        {
            MessageBox.Show("Aaargh! You got me!",
                            "Clone #" + Id + " says...");
        }
    }
}
