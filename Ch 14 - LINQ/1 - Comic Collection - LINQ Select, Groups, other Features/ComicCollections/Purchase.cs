using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicCollections
{
    class Purchase
    {
        public int Issue { get; set; }
        public decimal Price { get; set; }

        public static IEnumerable<Purchase> FindPurchases()
        {
            List<Purchase> purchases = new List<Purchase>()
            {
                new Purchase() { Issue = 68, Price = 225M},
                new Purchase() { Issue = 19, Price = 375M},
                new Purchase() { Issue = 6, Price = 3600M},
                new Purchase() { Issue = 57, Price = 13215M},
                new Purchase() { Issue = 36, Price = 660M},
            };
            return purchases;
        }


    }
}
