using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball
{
    class Pitcher
    {
        public ObservableCollection<string> PitcherSays = new ObservableCollection<string>();
        int pitchNumber = 0;

        public Pitcher(Ball ball)
        {
            ball.BallInPlay += Ball_BallInPlay;
        }

        private void Ball_BallInPlay(object sender, EventArgs e)
        {
            pitchNumber++;
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                if ((ballEventArgs.Distance < 95) && (ballEventArgs.Trajectory <60))
                {
                    CatchBall();
                }
                else
                {
                    CoverFirstBase();
                }
            }
        }

        private void CatchBall()
        {
            string caughtBall = "Pitch #" + pitchNumber + ": I caught the ball.";
            PitcherSays.Add(caughtBall);
        }

        private void CoverFirstBase()
        {
            string runFirstBase = "Pitch #" + pitchNumber + ": I covered first base.";
            PitcherSays.Add(runFirstBase);
        }
    }
}
