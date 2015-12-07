using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Baseball
{
    class BaseballSimulator
    {
        private Ball ball = new Ball();
        private Pitcher pitcher;
        private Fan fan;

        public ObservableCollection<string> FanSays { get { return fan.FanSays; } }
        public ObservableCollection<string> PitcherSays { get { return pitcher.PitcherSays; } }

        public int Trajectory { get; set; }
        public int Distance { get; set; }

        public BaseballSimulator()
        {
            pitcher = new Pitcher(ball);
            fan = new Fan(ball);
        }

        public void PlayBall()
        {
            Bat bat = ball.GetNewBat();
            BallEventArgs ballEventArgs = new BallEventArgs(Trajectory, Distance);
            bat.HitTheBall(ballEventArgs);

            // Below is the old implementation, until the event raiser was made protected.
            // In this way, the event can only be accessed by the Callback pattern set up in the bat object.
            // ball.OnBallInPlay(ballEventArgs);
        }
    }
}
