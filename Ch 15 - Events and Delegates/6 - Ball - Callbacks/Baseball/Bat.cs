using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball
{
    // Callback Pattern:
    // When one object passes a reference to a method to another object so it - and only it - can return information.
    // Events let any method subscribe to your object's events anonymously.
    delegate void BatCallback(BallEventArgs e);

    class Bat
    {
        private BatCallback hitBallCallback;

        // In a callback, other objects simply turn over their delegates and politely ask to be notified.
        // This prevents the bat event from being subscribed to by more than one ball object at a time.
        public Bat(BatCallback callbackDelegate)
        {
            this.hitBallCallback = new BatCallback(callbackDelegate);
        }
        
        public void HitTheBall(BallEventArgs e)
        {
            if (hitBallCallback != null)
            {
                hitBallCallback(e);
            }
        }
    }
}
