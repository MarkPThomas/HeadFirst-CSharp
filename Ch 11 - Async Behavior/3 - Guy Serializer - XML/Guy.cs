using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Runtime.Serialization;

namespace GuyXMLSerializer
{
    [DataContract(Namespace = "http://www.headfirstlabs.com/Chapter11")]
    class Guy
    {
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public int Age { get; private set; }
        [DataMember]
        public decimal Cash { get; private set; }

        // If this does not match an incoming XML file (e.g. it was changed in the program later on), the incoming data is ignored.
        // If the incoming XML has a node with this name, then it will match, so the XML files can be altered to match this.
        [DataMember (Name ="MyCard")]
        public Card TrumpCard { get; set; }

        public Guy(string name, int age, decimal cash)
        {
            Name = name;
            Age = age;
            Cash = cash;
            TrumpCard = Card.RandomCard();
        }

        public override string ToString()
        {
            return string.Format("My name is {0}, I'm {1}, I have {2} bucks, " +
                                    "and my trump card is {3}", Name, Age, Cash, TrumpCard);
        }
    }
}
