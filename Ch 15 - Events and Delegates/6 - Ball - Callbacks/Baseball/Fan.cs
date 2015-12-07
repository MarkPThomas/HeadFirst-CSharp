using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball
{
    class Fan
    {
        public ObservableCollection<string> FanSays = new ObservableCollection<string>();
        int pitchNumber = 0;

        public Fan(Ball ball)
        {
            // Event Handler Method
            // ball.BallInPlay += Ball_BallInPlay;

            // Generic Event Handler
            ball.BallInPlay += new EventHandler<BallEventArgs> (Ball_BallInPlay);
        }

        private void Ball_BallInPlay(object sender, EventArgs e)
        {
            pitchNumber ++ ;
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance > 400) && (ballEventArgs.Trajectory > 30))
                {
                    GrabGloveAndCatchBall();
                }
                else
                {
                    ScreamAndYell();
                }
            }
        }

        private void GrabGloveAndCatchBall()
        {
            FanSays.Add("Pitch #" + pitchNumber 
                        + ": Home run! I'm going for the ball!");
        }

        private void ScreamAndYell()
        {
            FanSays.Add("Pitch #" + pitchNumber
                        + ": Whoo-hoo! Yeah!");
        }
    }
}
