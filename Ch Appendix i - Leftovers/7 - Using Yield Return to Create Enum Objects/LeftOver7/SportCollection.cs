using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftOver7
{
    class SportCollection : IEnumerable<Sport>
    {
        public IEnumerator<Sport> GetEnumerator()
        {
            return new ManualSportEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class ManualSportEnumerator : IEnumerator<Sport>
        {
            int current = -1;

            public Sport Current
            {
                get
                {
                    return (Sport)current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                return; // Nothing to dispose.
            }

            /// <summary>
            /// Increments current and uses it to return the next sport in the enum.
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                int maxEnumValue = Enum.GetValues(typeof(Sport)).Length - 1;
                if ((int)current >= maxEnumValue)
                {
                    return false;
                }
                else
                {
                    current++;
                    return true;
                }
            }

            public void Reset()
            {
                current = 0;
            }
        }
    }
}
