using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Shield : Weapon, IDefense
    {
        private const int radius = 5;
        private const int damage = 1;

        public override string Name { get { return "Shield"; } }

        private const int defense = 1;
        public int Defense { get { return defense; } }
        
        public Shield(Game game, Point location)
            : base(game, location)
        { }

        public override void Attack(Direction direction, Random random)
        {
            // Shield provides passive defense
            DamageEnemy(direction, radius, damage, random);
        }
    }
}
