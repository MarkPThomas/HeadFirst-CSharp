using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class BluePotion: Weapon, IPotion
    {
        private const int health = 5;
        public override string Name { get { return "Blue Potion"; } }

        private bool used;
        public bool Used { get { return used; } }

        public BluePotion(Game game, Point location)
            : base(game, location)
        { }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(health, random);
            used = true;
        }
    }
}
