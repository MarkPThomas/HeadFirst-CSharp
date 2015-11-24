using System;
using System.IO;

namespace BeehiveManagement
{
    public class HiveLog
    {
        public bool ThrowHiveLogException { get; set; }
        public bool OpenNonExistingFile { get; set;}

        internal Stream OpenLogFile()
        {
            Stream newStream;

            if (ThrowHiveLogException)
            {
                throw new HiveLogException("OpenLogFile has no procedures defined!");
            }
            else if (OpenNonExistingFile)
            {
                newStream = File.OpenRead("NonExistingFile.txt");
                return newStream;
            }
            else
            {
                newStream = File.Create("NewLogFile.txt");
                return newStream;
            }
            
        }
    }
}