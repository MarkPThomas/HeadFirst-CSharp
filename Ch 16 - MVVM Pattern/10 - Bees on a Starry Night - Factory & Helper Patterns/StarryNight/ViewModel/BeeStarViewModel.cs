using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Threading;
// using DispatcherTimer = System.Windows.Threading.DispatcherTimer;
// using DispatcherTimer = Windows.UI.Xaml.DispatcherTimer;
using System.Windows;
// using UIElement = System.Windows.UIElement;
// using UIElement = Windows.UI.Xaml.UIElement;

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

        }

        void timer_Tick(object sender, object e)
        {

        }

        void BeeMovedHandler(object sender, BeeMovedEventArgs e)
        {

        }

        void StarChangedHandler(object sender, StarChangedEventArgs e)
        {
            
        }
    }
}
