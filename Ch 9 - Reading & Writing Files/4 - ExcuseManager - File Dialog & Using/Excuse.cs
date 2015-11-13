using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExcuseManager
{
    class Excuse
    {
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
            string[] files = Directory.GetFiles(directoryExcuses, "*.txt", SearchOption.TopDirectoryOnly);
            ExcusePath = files[random.Next(files.Length)];
        }

        public void OpenFile(string path) {
            using (StreamReader sr = new StreamReader(path))
            {
                Description = sr.ReadLine();
                Results = sr.ReadLine();
                LastUsed = Convert.ToDateTime(sr.ReadLine());
            }
        }

        public void Save(string path) {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(Description);
                sw.WriteLine(Results);
                sw.WriteLine(LastUsed);
            }
        }
    }
}
