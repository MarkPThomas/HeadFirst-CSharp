using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Threading;
// using DispatcherTimer = System.Windows.Threading.DispatcherTimer;
using System.Windows;
// using UIElement = System.Windows.UIElement;


namespace StarryNight.ViewModel
{
    using View;
    using Model;

    class BeeStarViewModel
    {
        private readonly ObservableCollection<UIElement> _sprites = new ObservableCollection<UIElement>();
        public INotifyCollectionChanged Sprites { get { return _sprites; } }

        private readonly Dictionary<Star, StarControl> _stars = new Dictionary<Star, StarControl>();
        private readonly List<StarControl> _fadedStars = new List<StarControl>();

        private BeeStarModel _model = new BeeStarModel();

        private readonly Dictionary<Bee, AnimatedImage> _bees = new Dictionary<Bee, AnimatedImage>();

        private DispatcherTimer _timer = new DispatcherTimer();

        public Size PlayAreaSize
        {
            get { return _model.PlayAreaSize; }
            set { _model.PlayAreaSize = value; }
        }
        
        public BeeStarViewModel()
        {
            _model.BeeMoved += BeeMovedHandler;
            _model.StarChanged += StarChangedHandler;

            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += timer_Tick;
            _timer.Start();
        }

        void timer_Tick(object sender, object e)
        {
            foreach (StarControl starControl in _fadedStars)
            {
                _sprites.Remove(starControl);
            }

            _model.Update();
        }

        void BeeMovedHandler(object sender, BeeMovedEventArgs e)
        {
            AnimatedImage beeControl = null;
            if (_bees.ContainsKey(e.BeeThatMoved))
            {
                beeControl = _bees[e.BeeThatMoved];
            }

            if (beeControl == null)
            {
                beeControl = BeeStarHelper.BeeFactory(e.BeeThatMoved.Width, e.BeeThatMoved.Height, TimeSpan.FromMilliseconds(20));
                BeeStarHelper.SetCanvasLocation(beeControl, e.X, e.Y);
                _bees.Add(e.BeeThatMoved, beeControl);
                _sprites.Add(beeControl);
            }
            else
            {
                BeeStarHelper.MoveElementOnCanvas(beeControl, e.X, e.Y);
            }
        }

        void StarChangedHandler(object sender, StarChangedEventArgs e)
        {
            StarControl starControl = null;
            if (_stars.ContainsKey(e.StarThatChanged))
            {
                starControl = _stars[e.StarThatChanged];
            }

            if (e.Removed && starControl != null)
            {    
                _fadedStars.Add(starControl);
                _stars.Remove(e.StarThatChanged);
                starControl.FadeOut();
                return;
            }
            else if (starControl == null)
            {
                starControl = new StarControl();
                if (_stars.ContainsKey(e.StarThatChanged))
                {
                    _stars[e.StarThatChanged] = starControl;
                }
                else
                {
                    _stars.Add(e.StarThatChanged, starControl);
                }            
                _sprites.Add(starControl);

                starControl.FadeIn();
                BeeStarHelper.SendToBack(starControl);
            }

            BeeStarHelper.SetCanvasLocation(starControl, e.StarThatChanged.Location.X, e.StarThatChanged.Location.Y);
        }
    }
}
