using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftOver7
{
    class SportCollectionYieldReturn : IEnumerable<Sport>
    {
        public IEnumerator<Sport> GetEnumerator()
        {
            int maxEnumValue = Enum.GetValues(typeof(Sport)).Length - 1;
            for (int i = 0; i <= maxEnumValue; i++)
            {
                // Automatically adds the MoveNext() method and Current property when returning IEnumerator or IEnumerator<T>
                yield return (Sport)i;
            }
        }
     

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Type 'indexer' tab, tab, to get a snippet used
        //public object this[int index]
        //{
        //    get { /* return the specified index here */ }
        //    set { /* set the specified index to value here */ }
        //}
        public Sport this[int index]
        {
            get { return (Sport)index; }
        }

    }
}
