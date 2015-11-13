using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class RedPotion : Weapon, IPotion
    {
        private const int health = 10;

        public override string Name { get { return "Red Potion"; } }

        private bool used;
        public bool Used { get { return used; }}
        

        public RedPotion(Game game, Point location)
            : base(game, location)
        {
            used = false;
        }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(health, random);
            used = true;
        }
    }
}
