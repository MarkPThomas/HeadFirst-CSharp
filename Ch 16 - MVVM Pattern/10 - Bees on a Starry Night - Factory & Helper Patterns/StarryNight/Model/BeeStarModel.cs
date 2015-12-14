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

        public BeeStarModel()
        {
            _playAreaSize = Size.Empty;
        }

        public void Update()
        {
            MoveOneBee();
            AddOrRemoveAStar();
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

        private Size _playAreaSize;
        public Size PlayAreaSize
        {
            get { return _playAreaSize; }
            set
            {
                CreateBees();
                CreateStars();
            }
        }

        private void CreateBees()
        {

        }

        private void CreateStars()
        {

        }

        private void CreateAStar()
        {

        }

        private void FindNonOverlappingPoint(Size size)
        {

        }

        private void MoveOneBee(Bee bee = null)
        {

        }

        private void AddOrRemoveAStar()
        {

        }
    }
}
