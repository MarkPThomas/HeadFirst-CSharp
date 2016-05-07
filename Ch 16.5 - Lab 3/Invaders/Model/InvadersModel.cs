using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Invaders.Model
{
    class InvadersModel
    {
        public readonly static Size PlayAreaSize = new Size(400, 300);
        public const int InitialStarCount = 50;
        public const int MaximumPlayerShots = 3;

        private readonly Random _random = new Random();

        public int Score { get; private set; }
        public int Wave { get; private set; }
        public int Lives { get; private set; }

        public bool GameOver { get; private set; }

        private TimeSpan _playerDyingTime = TimeSpan.FromMilliseconds(2500);
        private DateTime? _playerDied = null;
        public bool PlayerDying { get { return _playerDied.HasValue; } }

        private Player _player;

        private readonly List<Invader> _invaders = new List<Invader>();
        private readonly List<Shot> _playerShots = new List<Shot>();
        private readonly List<Shot> _invaderShots = new List<Shot>();
        private readonly List<Point> _stars = new List<Point>();

        private Direction _invaderDirection = Direction.Left;
        private bool _justMovedDown = false;

        private const int _invadersPerRow = 11;
        private const int _invaderRows = 6;

        private TimeSpan _invaderTimeIntervalLimit = TimeSpan.FromMilliseconds(1000);

        private DateTime _invadersLastMoved = DateTime.MinValue;

        public InvadersModel()
        {
            EndGame();
        }

        #region Methods: Public
        public void EndGame()
        {
            GameOver = true;
        }


        public void StartGame()
        {
            GameOver = false;

            foreach (Invader invader in _invaders)
            {
                OnShipChanged(invader, false);
            }
            _invaders.Clear();

            foreach (Shot shot in _playerShots)
            {
                OnShotMoved(shot, true);
            }
            _playerShots.Clear();

            foreach (Shot shot in _invaderShots)
            {
                OnShotMoved(shot, true);
            }
            _invaderShots.Clear();

            foreach (Point star in _stars)
            {
                OnStarChanged(star, true);
            }
            _stars.Clear();
            for (int i = 0; i < InitialStarCount; i++)
            {
                AddStar();
            }

            _player = new Player(new Point(_random.Next((int)(PlayAreaSize.Width - Player.PlayerSize.Width)),
                                           (int)(PlayAreaSize.Height) - Player.PlayerSize.Height));
            OnShipChanged(_player, false);
            Lives = 2;

            Wave = 0;
            NextWave();
        }

        public void FireShot()
        {
            if (_playerShots.Count() < MaximumPlayerShots)
            {
                Shot shot = new Shot(_player.Location, Direction.Up);
                _playerShots.Add(shot);
                OnShotMoved(shot, false);
            }
        }

        public void MovePlayer(Direction direction)
        {
            if (!PlayerDying)
            {
                _player.Move(direction, PlayAreaSize);
                OnShipChanged(_player, false);
            }
        }

        public void Twinkle()
        {
            if (_random.Next(2) == 0 && _stars.Count < 1.5 * InitialStarCount)
            {
                AddStar();
            }
            else if (_stars.Count() > 1.15 * InitialStarCount)
            {
                RemoveStar();
            }
        }

        
        public void Update(bool isPaused)
        {
            Twinkle();
            if (!PlayerDying && !isPaused)
            {
                if (_invaders.Count == 0)
                {
                    NextWave();
                }
                else
                {
                    MoveInvaders();
                }

                MoveShots(_playerShots);
                MoveShots(_invaderShots);

                ReturnFire();

                CheckForPlayerCollisions();
                CheckForInvaderCollisions();
            }
            else if (_playerDied != null)
            {
                // Indicate player dying process is done
                TimeSpan timeSincePlayerDied = DateTime.Now - (DateTime)_playerDied;
                if (timeSincePlayerDied.TotalMilliseconds >= _playerDyingTime.TotalMilliseconds)
                {
                    _playerDied = null;
                    OnShipChanged(_player, false);
                }
            }
        }

        internal void UpdateAllShipsAndStars()
        {
            OnShipChanged(_player, false);

            foreach (Invader invader in _invaders)
            {
                OnShipChanged(invader, false);
            }

            foreach (Point star in _stars)
            {
                OnStarChanged(star, false);
            }
        }
        #endregion

        #region Methods: Private

        private void AddStar()
        {
            Point star = new Point(_random.Next((int)PlayAreaSize.Width), _random.Next((int)PlayAreaSize.Height));
            _stars.Add(star);
            OnStarChanged(star, false);
        }

        private void RemoveStar()
        {
            Point star = _stars[_random.Next(_stars.Count)];
            OnStarChanged(star, true);
            _stars.Remove(star);
        }



        private void NextWave()
        {
            Wave += 1;
            // Scale the speed of the invaders to the wave number, so they get faster at higher levels
            _invaderTimeIntervalLimit = TimeSpan.FromMilliseconds(1000 / Wave);
            _invaders.Clear();
            
            double xPosition = 0;
            double yPosition = Invader.invaderPixelsPerMove * _invaderRows - 1;

            for (int i = 0; i < _invaderRows; i++)
            {
                for (int j = 0; j < _invadersPerRow; j++)
                {
                    Invader invader;
                    if (i < 2)
                    {
                        invader = new Invader(new Point(xPosition, yPosition), InvaderType.Star, 10);
                    }
                    else 
                    {
                        invader = new Invader(new Point(xPosition, yPosition), (InvaderType)(i - 1), 10*i);
                    }
                    _invaders.Add(invader);
                    
                    // Increment horizontal position
                    xPosition += Invader.invaderPixelsPerMove;
                }
                // Reset horizontal position & increment vertical position
                xPosition = 0;
                yPosition -= Invader.invaderPixelsPerMove;
            }
        }

        private void MoveInvaders()
        {
            TimeSpan timeSinceLastMoved = DateTime.Now - _invadersLastMoved;

            if (timeSinceLastMoved.TotalMilliseconds > _invaderTimeIntervalLimit.TotalMilliseconds)
            {
                CheckBoundaries();
                IncrementMoveInvaders();
                _invadersLastMoved = DateTime.Now;
            }
        }

        private void CheckBoundaries()
        {
            if (_invaderDirection == Direction.Right)
            {
                var invaders = from invader in _invaders
                               where invader.Location.X > PlayAreaSize.Width - 2 * Invader.invaderPixelsPerMove
                               select invader;
                if (invaders.Count() > 0)
                {
                    _invaderDirection = Direction.Left;
                    _justMovedDown = true;
                }
            }
            else
            {
                var invaders = from invader in _invaders
                               where invader.Location.X < 2 * Invader.invaderPixelsPerMove
                               select invader;
                if (invaders.Count() > 0)
                {
                    _invaderDirection = Direction.Right;
                    _justMovedDown = true;
                }
            }
        }

        private void IncrementMoveInvaders()
        {
            if (_justMovedDown)
            {
                foreach (Invader invader in _invaders)
                {
                    invader.Move(Direction.Down, PlayAreaSize);
                    OnShipChanged(invader, false);
                }
                _justMovedDown = false;
            }
            else
            {
                foreach (Invader invader in _invaders)
                {
                    invader.Move(_invaderDirection, PlayAreaSize);
                    OnShipChanged(invader, false);
                }
            }
        }


        private void ReturnFire()
        {
            if ((_invaderShots.Count() > Wave + 1) ||
                (_random.Next(10) < 10 - Wave)){ return; }

            Invader randomInvader = _invaders.GroupBy(q => q.Location.Y)
                                              .OrderBy(d => d.Key)
                                              .Select(g => g.ElementAt(_random.Next(g.Count())))
                                              .Last();

            InvaderFire(randomInvader);

            foreach (Invader invader in _invaders)
            {
                if (TakeAim(_player.Location.X, _player.Size.Width,
                            invader.Location.X, invader.Size.Width))
                {
                    InvaderFire(randomInvader);
                }
            }
        }

        private void InvaderFire(Invader invader)
        {
            // Get a point at the bottom center of the invader
            Point shotLocation = new Point((invader.Area.BottomRight.X + invader.Area.BottomLeft.X) / 2,
                                            invader.Area.Bottom);

            Shot newShot = new Shot(shotLocation, Direction.Down);
            _invaderShots.Add(newShot);

            OnShotMoved(newShot, false);
        }

        /// <summary>
        /// AI method for a more aggressive game. Taken from: http://gamecodeschool.com/android/coding-a-space-invaders-game/
        /// </summary>
        /// <param name="playerShipX"></param>
        /// <param name="playerShipWidth"></param>
        /// <returns></returns>
        public bool TakeAim(double playerShipX, double playerShipWidth,
                            double invaderX, double invaderWidth)
        {

            int randomNumber = -1;
            
            // If near the player
            if (((playerShipX + playerShipWidth) > invaderWidth && (playerShipX + playerShipWidth) < (invaderX + invaderWidth)) ||
                    (playerShipX > invaderX && playerShipX < (invaderX + invaderWidth)))
            {

                // A 1 in 150 chance to shoot
                randomNumber = _random.Next(150);
                if (randomNumber == 0)
                {
                    return true;
                }

            }

            // If firing randomly (not near the player) a 1 in 2000 chance
            randomNumber = _random.Next(2000);
            if (randomNumber == 0)
            {
                return true;
            }

            return false;
        }


        private void MoveShots(List<Shot> shots)
        {
            List<Shot> shotsRemoved = new List<Shot>();
            foreach (Shot shot in shots.ToList())
            {
                shot.Move();
                if (shot.Location.Y < 0 || PlayAreaSize.Height < shot.Location.Y)
                {
                    shots.Remove(shot);
                    OnShotMoved(shot, true);
                }
                else
                {
                    OnShotMoved(shot, false);
                }
            }
        }


        private void CheckForPlayerCollisions()
        {
            foreach (Shot shot in _invaderShots.ToList())
            {
                if (_player.Area.Contains(shot.Location))
                {
                    _playerDied = DateTime.Now;
                    Lives--;

                    if (Lives == 0)
                    {
                        EndGame();
                    }
                    OnShipChanged(_player, true);

                    _invaderShots.Remove(shot);
                    OnShotMoved(shot, true);
                }
            }
        }

        private void CheckForInvaderCollisions()
        {
            // Check if any player shots hit an invader
            foreach (Shot shot in _playerShots.ToList())
            {
                var deadInvaders = from invader in _invaders
                                   where invader.Area.Contains(shot.Location)
                                   select invader;
                if (deadInvaders.Count() > 0)
                {
                    Invader deadInvader = deadInvaders.ElementAt(0);
                    Score += deadInvader.Score; 
                    _invaders.Remove(deadInvader);
                    OnShipChanged(deadInvader, true);

                    _playerShots.Remove(shot);
                    OnShotMoved(shot, true);
                }
            }

            // Check if any invadors made it to the bottom of the battlefield
            var escapedInvaders = from invader in _invaders
                                  where invader.Area.Bottom >= PlayAreaSize.Height
                                  select invader;
            if (escapedInvaders.Count() > 0 )
            {
                EndGame();
            }
        }
        #endregion


        #region Events
        public event EventHandler<ShipChangedEventArgs> ShipChanged;
        protected void OnShipChanged(Ship ship, bool killed)
        {
            EventHandler<ShipChangedEventArgs> shipChanged = ShipChanged;
            if (shipChanged != null)
            {
                shipChanged(this, new ShipChangedEventArgs(ship, killed));
            }
        }

        public event EventHandler<ShotMovedEventArgs> ShotMoved;
        protected void OnShotMoved(Shot shot, bool disappeared)
        {
            EventHandler<ShotMovedEventArgs> shotMoved = ShotMoved;
            if (shotMoved != null)
            {
                shotMoved(this, new ShotMovedEventArgs(shot, disappeared));
            }
        }

        public event EventHandler<StarChangedEventArgs> StarChanged;
        protected void OnStarChanged(Point point, bool disappeared)
        {
            EventHandler<StarChangedEventArgs> starChanged = StarChanged;
            if (starChanged != null)
            {
                starChanged(this, new StarChangedEventArgs(point, disappeared));
            }
        }

        #endregion
    }
}
