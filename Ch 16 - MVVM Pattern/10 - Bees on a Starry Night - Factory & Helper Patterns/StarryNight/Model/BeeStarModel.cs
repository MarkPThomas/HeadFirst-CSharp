using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StarryNight.Model
{
    class BeeStarModel
    {
        // You can use readonly to create a constant struct value
        public static readonly Size StarSize = new Size(150, 100);

        private readonly Dictionary<Bee, Point> _bees = new Dictionary<Bee, Point>();
        private readonly Dictionary<Star, Point> _stars = new Dictionary<Star, Point>();
        private Random _random = new Random();

        private Size _playAreaSize;
        public Size PlayAreaSize
        {
            get { return _playAreaSize; }
            set
            {
                _playAreaSize = value;
                CreateBees();
                CreateStars();
            }
        }

        public BeeStarModel()
        {
            // Size.Empty is a value of Size that's reserved for an empty size.
            // It will be used only to create bees and stars when the play area is resized.
            _playAreaSize = Size.Empty;
        }

        public void Update()
        {
            MoveOneBee();
            AddOrRemoveAStar();
        }


        private void CreateBees()
        {
            if (_playAreaSize.IsEmpty)
            {
                return;
            }
            else if (_bees.Count > 0)
            {
                foreach (Bee bee in _bees.Keys)
                {
                    MoveOneBee(bee);
                }
            }
            else
            {
                int numBees = _random.Next(5, 16);
                for (int i = 5; i <= numBees; i++)
                {
                    CreateABee();
                }
            }
        }

        private void MoveOneBee(Bee bee = null)
        {
            if (_bees.Count == 0)
            {
                return;
            }
            else if (bee == null)
            {
                bee = _bees.Keys.ToList()[_random.Next(_bees.Count)];
            }

            Point newLocation = FindNonOverlappingPoint(bee.Size);
            bee.Location = newLocation;

            Point beeLocation = _bees[bee];
            beeLocation.X = newLocation.X;
            beeLocation.Y = newLocation.Y;

            OnBeeMoved(bee, newLocation.X, newLocation.Y);
        }

        private void CreateABee()
        {
            Size beeSize = new Size();
            beeSize.Width = _random.Next(40, 151);
            beeSize.Height = _random.Next(40, 151);

            Point beeLocation = FindNonOverlappingPoint(beeSize);

            Bee newBee = new Bee(beeLocation, beeSize);
            _bees.Add(newBee, beeLocation);

            OnBeeMoved(newBee, beeLocation.X, beeLocation.Y);
        }

        
        private void CreateStars()
        {
            if (_playAreaSize.IsEmpty)
            {
                return;
            }
            else if (_stars.Count > 0)
            {
                foreach (Star star in _stars.Keys)
                {
                    MoveOneStar(star);
                }
            }
            else
            {
                int numStars = _random.Next(5, 11);
                for (int i = 5; i <= numStars; i++)
                {
                    CreateAStar();
                }
            }
        }

        private void MoveOneStar(Star star = null)
        {
            if (_stars.Count == 0)
            {
                return;
            }
            else if (star == null)
            {
                star = _stars.Keys.ToList()[_random.Next(_stars.Count)];
            }

            Point starLocation = FindNonOverlappingPoint(StarSize);
            star.Location = starLocation;
            OnStarChanged(star, removed: false);
        }

        private void CreateAStar()
        {
            Point starLocation = FindNonOverlappingPoint(StarSize);

            Star newStar = new Star(starLocation);
            _stars.Add(newStar, starLocation);

            OnStarChanged(newStar, removed: false);
        }


        private void AddOrRemoveAStar()
        {
            if (_stars.Count <= 5)
            {
                CreateAStar();
            }
            else if (_stars.Count >= 20)
            {
                RemoveAStar();
            }
            else
            {
                if (_random.Next(2) == 0)
                {
                    CreateAStar();
                }
                else
                {
                    RemoveAStar();
                }
            }
        }

        private void RemoveAStar()
        {
            Star removedStar = _stars.Keys.ToList()[_random.Next(_stars.Count)];
            _stars.Remove(removedStar);
            OnStarChanged(removedStar, removed: true);
        }


        private static bool RectsOverlap(Rect r1, Rect r2)
        {
            r1.Intersect(r2);
            if (r1.Width > 0 || r1.Height > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Point FindNonOverlappingPoint(Size size)
        {
            Point randomPoint = new Point();
            for (int i = 0; i < 1000; i++)
            {
                randomPoint = new Point(Math.Max(0, _random.Next((int)PlayAreaSize.Width) - size.Width), Math.Max(0, _random.Next((int)PlayAreaSize.Height) - size.Height));
                Rect randomPosition = new Rect(randomPoint, size);

                var bees = from bee in _bees
                           where RectsOverlap(bee.Key.Position, randomPosition)
                           select bee.Key;
                if (bees.Count() == 0)
                {
                    var stars = from star in _stars
                               where RectsOverlap(new Rect(star.Value, StarSize), randomPosition)
                               select star.Key;
                }
            }
            return randomPoint;
        }


        public event EventHandler<BeeMovedEventArgs> BeeMoved;
        protected void OnBeeMoved(Bee beeThatMoved, double x, double y)
        {
            EventHandler<BeeMovedEventArgs> beeMoved = BeeMoved;
            if (beeMoved != null)
            {
                beeMoved(this, new BeeMovedEventArgs(beeThatMoved, x, y));
            }
        }

        public event EventHandler<StarChangedEventArgs> StarChanged;
        protected void OnStarChanged(Star starThatChanged, bool removed)
        {
            EventHandler<StarChangedEventArgs> starChanged = StarChanged;
            if (starChanged != null)
            {
                starChanged(this, new StarChangedEventArgs(starThatChanged, removed));
            }
        }
    }
}
