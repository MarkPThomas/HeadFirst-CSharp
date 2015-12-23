using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invaders.View;
using Invaders.Model;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Invaders.ViewModel
{
    class InvadersViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<FrameworkElement> _sprites = new ObservableCollection<FrameworkElement>();
        public INotifyCollectionChanged Sprites {  get { return _sprites; } }

        public bool GameOver { get { return _model.GameOver; } }


        private readonly ObservableCollection<object> _lives = new ObservableCollection<object>();
        public INotifyCollectionChanged Lives { get { return _lives; } }

        public bool Paused { get; set; }
        private bool _lastPaused = true;

        /// <summary>
        /// Multiplier that, when multiplied with any X, Y, Width and Height value, 
        /// translates that value from the 400x300 model coordinates to the correct 
        /// coordinate Canvase control in the play area.
        /// </summary>
        public static double Scale { get; private set; }

        public int Score { get; private set; }

        public Size PlayAreaSize
        {
            set
            {
                Scale = value.Width / 405;
                _model.UpdateAllShipsAndStars();
                RecreateScanLines();
            }
        }

        private readonly InvadersModel _model = new InvadersModel();
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private FrameworkElement _playerControl = null;
        private bool _playerFlashing = false;
        private readonly Dictionary<Invader, FrameworkElement> _invaders = new Dictionary<Invader, FrameworkElement>();
        private readonly Dictionary<FrameworkElement, DateTime> _shotInvaders = new Dictionary<FrameworkElement, DateTime>();
        private readonly Dictionary<Shot, FrameworkElement> _shots = new Dictionary<Shot, FrameworkElement>();
        private readonly Dictionary<Point, FrameworkElement> _stars = new Dictionary<Point, FrameworkElement>();
        private readonly List<FrameworkElement> _scanLines = new List<FrameworkElement>();

        public InvadersViewModel()
        {
            Scale = 1;

            _model.ShipChanged += ModelShipChangedEventHandler;
            _model.ShotMoved += ModelShotMovedEventHandler;
            _model.StarChanged += ModelStarChangedEventHandler;

            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += TimerTickEventHandler;

            EndGame();
        }

        public void StartGame()
        {
            Paused = false;

            foreach (var invader in _invaders.Values)
            {
                _sprites.Remove(invader);
            }

            foreach (var shot in _shots.Values)
            {
                _sprites.Remove(shot);
            }

            _model.StartGame();
            OnPropertyChanged("GameOver");
            _timer.Start();
        }



        public void RecreateScanLines()
        {
            foreach (FrameworkElement scanLine in _scanLines)
            {
                if (_sprites.Contains(scanLine))
                {
                    _sprites.Remove(scanLine);
                }
            }
            _scanLines.Clear();

            for (int y = 0; y < 300; y += 2)
            {
                FrameworkElement scanLine = InvadersHelper.ScanLineFactory(y, 400, Scale);
                _scanLines.Add(scanLine);
                _sprites.Add(scanLine);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private DateTime? _leftAction = null;
        private DateTime? _rightAction = null;

        #region Methods: Internal
        internal void LeftGestureStarted()
        {
            _leftAction = DateTime.Now;
        }

        internal void RightGestureStarted()
        {
            _rightAction = DateTime.Now;
        }

        internal void LeftGestureCompleted()
        {
            _leftAction = null;
        }

        internal void RightGestureCompleted()
        {
            _rightAction = null;
        }

        internal void KeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                _model.FireShot();
            }

            if (e.Key == Key.Left)
            {
                _leftAction = DateTime.Now;
            }

            if (e.Key == Key.Right)
            {
                _rightAction = DateTime.Now;
            }

            if (e.Key == Key.P)
            {
                Paused = true;
                // TODO: Figure out how to pause the game
            }
        }

        internal void KeyUp(KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                _leftAction = null;
            }
            else if (e.Key == Key.Right)
            {
                _rightAction = null;
            }
        }
        #endregion

        #region Methods: Private
        private void TimerTickEventHandler(object sender, object e)
        {
            if (_lastPaused != Paused)
            {
                // Use the _lastPaused field to fire a PropertyChanged event any time the Paused property changes
            }
            if (!Paused)
            {
                // if _leftAction and _rightAction have a value, use the one with the later time to choose a direction to move the player
                // if not, choose the one with a value and use that to pass to _model.MovePlayer()
            }

            // Tell the InvadersModel to upate itself
            // Check Score property
            // If Score property != _model.Score, update it and fire a PropertyChanged event

            // Update Lives so it matches _model.Lives by either adding or removing a new object()

            foreach (FrameworkElement control in _shotInvaders.Keys.ToList())
            {
                // Each key in the _shotInvaders Dictionary is an AnimatedImage control, and its value is the time that it died.
                // It takes 0.5 sec for the invader fade-out animation to complete, so any invader who died longer ago should
                //  be removed from both _sprites and _shotInvaders
                
            }

            // If the game is over, fire a PropertyChanged event and stop the timer
        }

        private void ModelShipChangedEventHandler(object sender, ShipChangedEventArgs e)
        {
            if (!e.Killed)
            {
                if (e.ShipUpdated is Invader)
                {
                    Invader invader = e.ShipUpdated as Invader;

                    // If this invader is not in the _invaders collection, use the InvadersControlFactory() to create a new control and
                    // add it to the collection and sprites.
                    // Otherwise, move the invader control to its correct location and resize it, including the Scale value.

                    InvadersHelper.ResizeElement(invaderControl,
                                                 invader.Size.Width * Scale,
                                                 invader.Size.Height * Scale);
                }
                else if (e.ShipUpdated is Player)
                {
                    // If _playerFlashing is true, stop it from flashing.
                    // If _playerControl is null and use PlayerControlFactory() and add new player to the sprites
                    // Otherwise move and resize player
                }
            }
            else
            {
                if (e.ShipUpdated is Invader)
                {
                    // If invader isn't null, call InvaderShot() and cast it to AnimatedImages.
                    // Add invader to _shotInvaders and remove it from _invadors
                    // _shotInvaders dictionary contains the time that each invader was shot.
                    // ViewModel doesn't remove the invader's AnimatedImage control from the sprites until it's finished fading out.
                }
                else if (e.ShipUpdated is Player)
                {
                    // Cast _playerControl to AnimatedImage, start it flashing, and set the _playerFlashing field to true.
                    // This animation can keep going until the ViewModel gets another ShipChanged event from the model,
                    //  because that means gameplay has resumed
                }
            }
        }

        private void ModelShotMovedEventHandler(object sender, ShotMovedEventArgs e)
        {
            if (!e.Disappeared)
            {
                // if shot is NOT a key in the _shots dictionary, use its factory method to create a new shot control and add it to _shots & _sprites.
                // Else look up its controls and use the helper method to move it using its location property
            }
            else
            {
                // Check _shots to see if it is there. 
                // If so, remove its control control from _sprites, and remove Shot from _shots
            }
        }

        private void ModelStarChangedEventHandler(object sender, StarChangedEventArgs e)
        {
            if (e.Disappeared && _stars.ContainsKey(e.Point))
            {
                // Look up control in _stars and remove it from _sprites
            }
            else
            {
                // Not likely to occur
                // Add a shooting star: Look up star control in _stars and use a helper method to move it to the new location
            }
        }
        #endregion

        // Additional:
        // 1. Add sounds
        // 2. Add a mothership
        // 3. Add shields
        // 4. Add divebombers
        // 5. Add more weapons
        // 6. Add a preferences command to the Settings Charm
    }
}
