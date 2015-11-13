using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Player : Mover
    {
        public int HitPoints { get; private set; }

        private Weapon equippedWeapon;
        private List<Weapon> inventory = new List<Weapon>();
        public IEnumerable<string> Weapons {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                {
                    names.Add(weapon.Name);
                }
                return names;
            }
        }

        public Player(Game game, Point location)
            : base(game, location)
        {
            HitPoints = 10;
        }

        public void Attack(Direction direction, Random random)
        {
            if (equippedWeapon == null) { return; }

            equippedWeapon.Attack(direction, random);
            if (equippedWeapon is IPotion || 
                equippedWeapon is IExplosive)
            {
                // Drink potion or explode bomb
                inventory.Remove(equippedWeapon);
                equippedWeapon = null;
            }
        }

        public void Hit(int maxDamage, Random random)
        {
            int reducedMaxDamage = 0;
            foreach (Weapon weapon in inventory)
            {
                if (weapon is IDefense)
                {
                    IDefense defensiveWeapon = weapon as IDefense;
                    reducedMaxDamage += defensiveWeapon.Defense;
                }
            }
            HitPoints -= random.Next(1, Math.Max(0, maxDamage - reducedMaxDamage));
        }

        public void IncreaseHealth(int health, Random random)
        {
            HitPoints += random.Next(1, health);
        }

        /// <summary>
        /// Equips a player with a specified weapon from his inventory. A player can only have one weapon equipped at a time.
        /// </summary>
        /// <param name="weaponName"></param>
        public void Equip(string weaponName)
        {
            foreach (Weapon weapon in inventory)
            {
                if (weapon.Name == weaponName)
                {
                    equippedWeapon = weapon;
                }
            }
        }

        public void Move(Direction direction)
        {
            location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            {
                // See if the weapon is nearby, and possibly pick it up.
                if (Nearby(game.WeaponInRoom.Location, 10))
                {
                    game.WeaponInRoom.PickUpWeapon();
                    inventory.Add(game.WeaponInRoom);
                    if (inventory.Count == 1)
                    {
                        Equip(game.WeaponInRoom.Name);
                    }
                }
            }
        }
    }
}
