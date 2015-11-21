using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GuyXMLSerializer
{
    [DataContract(Namespace = "http://www.headfirstlabs.com/Chapter11")]
    // If this namespace is different than the containing class, then:
    //  1. It is listed as a new namespace "xmlns:a" attrubite to the class folder.
    //  2. Properties are prexied with the "a", such as "a:Suit".
    public class Card
    {
        [DataMember]
        public Suits Suit{get; set; }

        [DataMember]
        public Values Value{get; set; }

        private static Random r = new Random();

        public string Name
        {
            get{ return Value.ToString() + " of " + Suit.ToString(); }
        }

        public override string ToString()
        {
            return Name;
        }

        public static Card RandomCard()
        {
            return new Card((Suits)r.Next(4), (Values)r.Next(1, 14));
        }


        public Card(Suits suit, Values value)
        {
            this.Suit = suit;
            this.Value = value;
        }
    }
}
