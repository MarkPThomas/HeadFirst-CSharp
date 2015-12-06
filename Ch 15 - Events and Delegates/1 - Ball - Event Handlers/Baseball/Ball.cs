using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball
{
    class Ball
    {
        // Event Handler Method
        // public event EventHandler BallInPlay;

        // Generic Event Handler Method
        // Communicates what sort of event argument should be supplied to the event.
        public event EventHandler<BallEventArgs> BallInPlay;
        public void OnBallInPlay(BallEventArgs e)
        {
            EventHandler<BallEventArgs> ballInPlay = BallInPlay;
            if (ballInPlay != null)
            {
                ballInPlay(this, e);
            }
        }
    }
}
