using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadFirst.CSharp.Leftover3;
using HeadFirst.VisualBasic.LeftOver3;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Guy guy = new Guy("Joe", 43, 125);
            HiThereWriter.HiThere(guy.Name);

            GoAwayWriter.GoAway(guy.Name);
        }
    }
}
