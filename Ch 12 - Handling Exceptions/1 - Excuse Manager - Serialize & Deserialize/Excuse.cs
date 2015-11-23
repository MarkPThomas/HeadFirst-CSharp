using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace ExcuseManager
{
    [Serializable]
    class Excuse
    {
        public const string EXCUSE_FILE_EXTENSION = ".excuse";
        public string Description { get; set; }
        public string Results { get; set; }
        public DateTime LastUsed { get; set; }
        public string ExcusePath { get; set; }

        public Excuse() {
            ExcusePath = "";
        }

        public Excuse(string excusePath)
        {
            ExcusePath = excusePath;
        }

        public Excuse(string directoryExcuses, Random random)
        {   
            string[] files = Directory.GetFiles(directoryExcuses, "*" + EXCUSE_FILE_EXTENSION, SearchOption.TopDirectoryOnly);
            ExcusePath = files[random.Next(files.Length)];
        }

        public void OpenFile(string path)
        {
            try
            {
                ExcusePath = path;

                Excuse fileExcuse;
                BinaryFormatter bf = new BinaryFormatter();
                using (Stream input = File.OpenRead(path))
                {
                    fileExcuse = (Excuse)bf.Deserialize(input);
                }

                Description = fileExcuse.Description;
                Results = fileExcuse.Results;
                LastUsed = fileExcuse.LastUsed;
            }
            //// (1) The most ideal way of catching an exception. HANDLING IT.
            //catch (SerializationException)
            //{
            //    MessageBox.Show("Unable to read " + ExcusePath);
            //    LastUsed = DateTime.Now;
            //}
            //// (2) Below is standard for Visual Basic, but the IDE throws a warning of exS not being used.
            //catch (SerializationException exS)
            //{
            //    MessageBox.Show("Unable to read " + ExcusePath);
            //    LastUsed = DateTime.Now;
            //}
            // (3) Below is standard for Visual Basic, where exS can be used in various ways, such as in debugging, or exposing the exception in a messagebox or console output.
            //catch (SerializationException exS)
            //{
            //    MessageBox.Show("Unable to read " + ExcusePath + "due to the following : " + Environment.NewLine + Environment.NewLine +
            //                exS.Message + Environment.NewLine + Environment.NewLine +
            //                "From : " + Environment.NewLine + Environment.NewLine + 
            //                exS.StackTrace);
            //    LastUsed = DateTime.Now;
            //}
            // (4) Basic snippets result. Catches all exceptions. 'Throw' message at this point.
            //catch (Exception)
            //{
            //    throw;
            //}
            //// (5) This solves the problem of variation 2, as far as the exception variable being unused.
            //// 'e' can then be conveniently investigated in the debugger rather than using the psuedovariable '$exception'.
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }

        public void Save(string path) {
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream output = File.Create(path))
            {
                bf.Serialize(output,this);
            }
        }
    }
}
