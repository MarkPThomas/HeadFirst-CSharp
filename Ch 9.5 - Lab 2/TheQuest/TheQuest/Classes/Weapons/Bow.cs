using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Bow : Weapon
    {
        private const int radius = 30;
        private const int damage = 1;

        public override string Name { get { return "Bow"; } }

        public Bow(Game game, Point location)
            : base(game, location)
        { }

        public override void Attack(Direction direction, Random random)
        {
            if (DamageEnemy(direction, radius, damage, random)) { return; }
        }
    }
}
