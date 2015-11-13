using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

        public void OpenFile(string path) {
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

        public void Save(string path) {
            BinaryFormatter bf = new BinaryFormatter();
            using (Stream output = File.Create(path))
            {
                bf.Serialize(output,this);
            }
        }
    }
}
