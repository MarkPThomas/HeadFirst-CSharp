using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HexDumper
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("usage: HexDumper file-to-dump");
                Environment.Exit(1);
            }
            if (!File.Exists(args[0]))
            {
                Console.Error.WriteLine("File does not exist: {0}", args[0]);
                Environment.Exit(2);
            }
            using (Stream input = File.OpenRead(args[0]))
            {
                int position = 0;
                int bytesPerLine = 16;
                int bytesPerSegment = 8;
                byte[] buffer = new byte[bytesPerLine];

                // Line written as:
                // {4-character hex position}: {2-character bytes 1-8} -- {2-character bytes 9-16}    {Text representation of the line}
                while (position < input.Length)
                {
                    int charactersRead = input.Read(buffer, 0, buffer.Length);
                    if (charactersRead > 0)
                    {
                        // 0:x4 means to write parameter 0 as a 4-character hex number
                        Console.Write("{0}: ", string.Format("{0:x4}", position));
                        position += charactersRead;

                        for (int i = 0; i < bytesPerLine; i++)
                        {
                            if (i < charactersRead)
                            {
                                // Write parameter as a 2-character hex number
                                string hex = string.Format("{0:x2}", buffer[i]);
                                Console.Write(hex + " ");
                            }
                            else
                            {
                                Console.Write("   ");
                            }

                            // Write divide between byte segment
                            if (i == (bytesPerSegment-1))
                            {
                                Console.Write("-- ");
                            }

                            // Characters byte values outside of this range values don't print to text well, so they are blocked out as periods.
                            if (buffer[i] < 32 || 250 < buffer[i])
                            {
                                buffer[i] = (byte)'.';
                            }
                        }

                        // Write bytes out as text
                        string bufferContents = Encoding.UTF8.GetString(buffer);
                        Console.WriteLine("    " + bufferContents);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
