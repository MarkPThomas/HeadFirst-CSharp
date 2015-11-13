using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Quiver : Weapon
    {
        private const int radius = 30;
        private const int damage = 1;

        public override string Name { get { return "Quiver"; } }

        public Quiver(Game game, Point location)
            : base(game, location)
        { }

        public override void Attack(Direction direction, Random random)
        {
            // Shoot in all directions
            DamageEnemy(Direction.Up, radius, damage, random);
            DamageEnemy(Direction.Left, radius, damage, random);
            DamageEnemy(Direction.Down, radius, damage, random);
            DamageEnemy(Direction.Right, radius, damage, random);
        }
    }
}
