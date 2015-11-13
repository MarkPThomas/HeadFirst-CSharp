using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Bat : Enemy
    {
        private const int damage = 2;
        private const int hitPoints = 6;

        public Bat(Game game, Point location)
            : base(game, location, hitPoints)
        { }

        public override void Move(Random random)
        {
            if (Dead) { return; }

            if (random.Next(2) == 0)
            {
                Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            }
            else
            {
                Move((Direction)random.Next(3), game.Boundaries);
            }

            if (NearPlayer())
            {
                game.HitPlayer(damage, random);
            }
        }
    }
}
