using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Duck> ducks = new List<Duck>(){
                new Duck() {Kind = KindOfDuck.Mallard, Size = 17},
                new Duck() {Kind = KindOfDuck.Muscovy, Size = 18},
                new Duck() {Kind = KindOfDuck.Decoy, Size = 14},
                new Duck() {Kind = KindOfDuck.Mallard, Size = 11},
                new Duck() {Kind = KindOfDuck.Muscovy, Size = 14},
                new Duck() {Kind = KindOfDuck.Decoy, Size = 13}
            };

            Console.WriteLine("Ducks compared within class by size");
            ducks.Sort();
            PrintDucks(ducks);

            Console.WriteLine("Ducks compared with comparer class by size");
            DuckComparerBySize sizeComparer = new DuckComparerBySize();
            ducks.Sort(sizeComparer);
            PrintDucks(ducks);

            Console.WriteLine("Ducks compared with comparer class by kind");
            DuckComparerByKind kindComparer = new DuckComparerByKind();
            ducks.Sort(kindComparer);
            PrintDucks(ducks);

            
            DuckComparer comparer = new DuckComparer();
            Console.WriteLine("Ducks compared with enum comparer class by kind then size");
            comparer.SortBy = SortCriteria.KindThenSize;
            ducks.Sort(comparer);
            PrintDucks(ducks);

            Console.WriteLine("Ducks compared with enum comparer class by size then kind");
            comparer.SortBy = SortCriteria.SizeThenKind;
            ducks.Sort(comparer);
            PrintDucks(ducks);

            Console.ReadKey();
        }

        public static void PrintDucks(List<Duck> ducks)
        {
            foreach (Duck duck in ducks)
            {
                Console.WriteLine(duck.Size.ToString() + "-inch " + duck.Kind.ToString());
            }
            Console.WriteLine("End of ducks!\n\r");
        }



    }
}
