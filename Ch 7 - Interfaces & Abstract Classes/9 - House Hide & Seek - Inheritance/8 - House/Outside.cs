using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Outside : Location
    {
        private bool hot;

        public override string Description
        {
            get
            {
                string outsideDescription =  base.Description;
                if (hot)
                    outsideDescription += " It's very hot here.";

                return outsideDescription;
            }
        }

        public Outside(string name, bool hot)
            :base(name)
        {
            this.hot = hot;
        }

    }
}
