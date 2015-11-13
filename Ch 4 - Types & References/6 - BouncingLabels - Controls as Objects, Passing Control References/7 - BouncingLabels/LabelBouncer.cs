using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingLabels
{
    class LabelBouncer
    {
        public Label MyLabel;
        public bool GoingForward = true;

        public void Move()
        {
            if (MyLabel != null)
            {
                if (GoingForward)
                {
                    MyLabel.Left += 5;
                    if (MyLabel.Left >= MyLabel.Parent.Width - MyLabel.Width)
                    {
                        GoingForward = false;
                    }
                }
                else
                {
                    MyLabel.Left -= 5;
                    if (MyLabel.Left <= 0)
                    {
                        GoingForward = true;
                    }
                }
            }
        }
    }
}
