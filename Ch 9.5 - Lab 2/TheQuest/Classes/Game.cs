using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace TheQuest
{
    class Game
    {
        #region Properties and Fields

        private int enemyTurnsPerGameTurn = 1;
        public IEnumerable<Enemy> Enemies { get; private set; }
        public Weapon WeaponInRoom { get; private set; }

        private Player player;
        public Point PlayerLocation { get { return player.Location; } }
        public int PlayerHitPoints { get { return player.HitPoints; } }
        public IEnumerable<string> PlayerWeapons { get { return player.Weapons; } }

        private int level = 0;
        public int Level { get { return level; } }

        private Rectangle boundaries;
        public Rectangle Boundaries { get { return boundaries; } }
        #endregion

        #region Initialization
        public Game(Rectangle boundaries)
        {
            this.boundaries = boundaries;
            player = new Player(this,
                                new Point(boundaries.Left + 10, boundaries.Top + 70));
        }
        #endregion

        #region Movements
        /// <summary>
        /// Moves player and also moves all enemies and magic weapons.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="random"></param>
        public void Move(Direction direction, Random random)
        {
            PlayerMove(direction);
            SceneMove(random);
        }
        
        /// <summary>
        /// Moves player without updating enemy or weapon positions.
        /// </summary>
        /// <param name="direction"></param>
        public void PlayerMove(Direction direction)
        {
            player.Move(direction);
        }

        /// <summary>
        /// Moves enemies and magic weapons.
        /// </summary>
        /// <param name="random"></param>
        public void SceneMove(Random random)
        {
            // Move enemies
            for (int i = 0; i < enemyTurnsPerGameTurn; i++)
            {
                foreach (Enemy enemy in Enemies)
                {
                    enemy.Move(random);
                }

                // Move magic potion weapon at random intervals in random directions.
                if (WeaponInRoom is IPotion)
                {
                    if (random.Next(0, 3) == 0)
                    {
                        Direction magicMoveDirection = (Direction)random.Next(1, 5);
                        WeaponInRoom.Move(magicMoveDirection, boundaries);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="random"></param>
        public void Attack(Direction direction, Random random)
        {
            PlayerAttack(direction, random);
            SceneMove(random);
        }
        /// <summary>
        /// Attacks with player only.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="random"></param>
        public void PlayerAttack(Direction direction, Random random)
        {
            player.Attack(direction, random);
        }


        public Direction OrientPlayer(Point locationOrient)
        {
            return player.Orient(locationOrient);
        }

        private Point GetRandomLocation(Random random)
        {
            return new Point(boundaries.Left + random.Next(boundaries.Right / 10 - boundaries.Left / 10) * 10,
                             boundaries.Top + random.Next(boundaries.Bottom / 10 - boundaries.Top / 10) * 10);
        }

        #endregion

        #region Actions
        public void Equip(string weaponName)
        {
            player.Equip(weaponName);
        }

        public bool CheckPlayerInventory(string weaponName)
        {
            return player.Weapons.Contains(weaponName);
        }

        public void HitPlayer(int maxDamage, Random random)
        {
            player.Hit(maxDamage, random);
        }

        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreaseHealth(health, random);
        }
        #endregion

        #region Levels
        public void NewLevel(Random random)
        {
            level++;

            // Set enemies
            switch (level)
            {
                case 1:
                    Enemies = new List<Enemy>()
                        {
                            new Bat(this, GetRandomLocation(random)),
                        };
                    break;
                case 2:
                    Enemies = new List<Enemy>()
                        {
                            new Ghost(this, GetRandomLocation(random)),
                        };
                    enemyTurnsPerGameTurn = 4;
                    break;
                case 3:
                    Enemies = new List<Enemy>()
                        {
                            new Ghoul(this, GetRandomLocation(random)),
                        };
                    enemyTurnsPerGameTurn = 4;
                    break;
                case 4:
                    Enemies = new List<Enemy>()
                        {
                            new Bat(this, GetRandomLocation(random)),
                            new Ghost(this, GetRandomLocation(random)),
                        };
                    enemyTurnsPerGameTurn = 2;
                    break;
                case 5:
                    Enemies = new List<Enemy>()
                        {
                            new Bat(this, GetRandomLocation(random)),
                            new Ghoul(this, GetRandomLocation(random)),
                        };
                    enemyTurnsPerGameTurn = 2;
                    break;
                case 6:
                    Enemies = new List<Enemy>()
                        {
                            new Ghost(this, GetRandomLocation(random)),
                            new Ghoul(this, GetRandomLocation(random)),
                        };
                    enemyTurnsPerGameTurn = 4;
                    break;
                case 7:
                    Enemies = new List<Enemy>()
                        {
                            new Bat(this, GetRandomLocation(random)),
                            new Ghost(this, GetRandomLocation(random)),
                            new Ghoul(this, GetRandomLocation(random)),
                        };
                    enemyTurnsPerGameTurn = 3;
                    break;
                case 8:
                    Enemies = new List<Enemy>()
                        {
                            new Bat(this, GetRandomLocation(random)),
                            new Ghost(this, GetRandomLocation(random)),
                            new Ghoul(this, GetRandomLocation(random)),
                            new Wizard(this, GetRandomLocation(random))
                        };
                    enemyTurnsPerGameTurn = 2;
                    break;
                case 9:
                    Enemies = new List<Enemy>()
                        {
                            new Bat(this, GetRandomLocation(random)),
                            new Ghost(this, GetRandomLocation(random)),
                            new Ghoul(this, GetRandomLocation(random)),
                            new Wizard(this, GetRandomLocation(random))
                        };
                    enemyTurnsPerGameTurn = 3;
                    break;
                case 10:
                    Application.Exit();
                    break;
                default:
                    MessageBox.Show("An error has occurred. The program will close.");
                    Application.Exit();
                    break;
            }

            SetWeaponByLevel(random);
        }

        private void SetWeaponByLevel(Random random)
        {
            if (!CheckPlayerInventory("Sword") &&
                level == 1)
            {
                WeaponInRoom = new Sword(this, GetRandomLocation(random));
            }
            else if (!CheckPlayerInventory("Bow") &&
                (level == 3 || level == 4))
            {
                WeaponInRoom = new Bow(this, GetRandomLocation(random));
            }
            else if (!CheckPlayerInventory("Battle Axe") &&
                (level == 5 || level == 7))
            {
                WeaponInRoom = new BattleAxe(this, GetRandomLocation(random));
            }
            else if (!CheckPlayerInventory("Mace") &&
                (level == 6 || level == 7))
            {
                WeaponInRoom = new Mace(this, GetRandomLocation(random));
            }
            else if (!CheckPlayerInventory("Quiver") &&
                level == 7) 
            {
                WeaponInRoom = new Quiver(this, GetRandomLocation(random));
            }
            else if (!CheckPlayerInventory("Bomb") &&
                level == 8)
            {
                WeaponInRoom = new Bomb(this, GetRandomLocation(random));
            }
            else if (!CheckPlayerInventory("Shield") &&
                level == 9)
            {
                WeaponInRoom = new Shield(this, GetRandomLocation(random));
            }
            else if (!CheckPlayerInventory("Blue Potion") &&
                (level == 2 || level == 4 || level == 8))
            {
                WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
            }
            else if (!CheckPlayerInventory("Red Potion") &&
                (level == 4 || level == 5 || level == 7) || level == 9)
            {
                WeaponInRoom = new RedPotion(this, GetRandomLocation(random));
            }
        }

        public void RestartLevel(Random random)
        {
            // New level increments by one, so roll back by 1 to start
            level--;
            NewLevel(random);

            // Restart player with fresh health
            player.ResurrectPlayer();
        }
        #endregion
    }
}
