using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class BattleAxe : Weapon
    {
        private const int radius = 10;
        private const int damage = 8;

        public override string Name { get { return "BattleAxe"; } }

        public BattleAxe(Game game, Point location)
            : base(game, location)
        { }

        public override void Attack(Direction direction, Random random)
        {
            if (DamageEnemy(direction, radius, damage, random)) { return; }
        }

    }
}
