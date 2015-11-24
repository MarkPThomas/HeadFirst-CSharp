using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CloneGarbage
{
    [Serializable]
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
            string fileName = @"C:\Temp\Clone.dat";
            string dirName = @"C:\Temp";
            if (!File.Exists(fileName))
            {
                Directory.CreateDirectory(dirName);
            }
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream output = File.OpenWrite(fileName))
            {
                bf.Serialize(output, this);
            }

            MessageBox.Show("Must...serialize...object!",
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
