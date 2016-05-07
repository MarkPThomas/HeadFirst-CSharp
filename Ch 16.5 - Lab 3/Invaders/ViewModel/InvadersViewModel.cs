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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private readonly ObservableCollection<FrameworkElement> _sprites = new ObservableCollection<FrameworkElement>();
        public INotifyCollectionChanged Sprites {  get { return _sprites; } }

        public bool GameOver { get { return _model.GameOver; } }

        public int Wave { get { return _model.Wave; } }

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
                Scale = value.Width / 400;
                _model.UpdateAllShipsAndStars();
               // RecreateScanLines();
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

        private TimeSpan _timeLimitInvadersFadeoutSeconds = TimeSpan.FromSeconds(0.5);        

        public InvadersViewModel()
        {
            Scale = 1;

            _model.ShipChanged += ModelShipChangedEventHandler;
            _model.ShotMoved += ModelShotMovedEventHandler;
            _model.StarChanged += ModelStarChangedEventHandler;

            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += TimerTickEventHandler;

            //EndGame();
            StartGame();
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

        public void EndGame()
        {
            _model.EndGame();
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

        private DateTime? _leftAction = null;
        private DateTime? _rightAction = null;
        private DateTime? _fireAction = null;

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
            if (e.Key == Key.P)
            {
                if (Paused)
                {
                    Paused = false;
                }
                else
                {
                    Paused = true;
                }
            }

            if (Paused) { return; }

            if (e.Key == Key.Space)
            {
                _fireAction = DateTime.Now;
            }

            if (e.Key == Key.Left)
            {
                _leftAction = DateTime.Now;
            }

            if (e.Key == Key.Right)
            {
                _rightAction = DateTime.Now;
            }

            if (GameOver && e.Key == Key.Space)
            {
                StartGame();
            }
        }

        internal void KeyUp(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    _leftAction = null;
                    break;
                case Key.Right:
                    _rightAction = null;
                    break;
                case Key.Space:
                    _fireAction = null;
                    break;
            }

        }
        #endregion

        #region Methods: Private
        private void TimerTickEventHandler(object sender, object e)
        {
            if (_lastPaused != Paused)
            {
                _lastPaused = Paused;
                OnPropertyChanged("Paused");
            }
            if (!Paused)
            // Move player
            {
                if (_leftAction != null && _rightAction != null)
                {
                    if (_leftAction > _rightAction)
                    {
                        if (_fireAction != null && _fireAction > _leftAction)
                        {
                            _model.FireShot();
                        }
                        else
                        {
                            _model.MovePlayer(Direction.Left);
                        }
                    }
                    else
                    {
                        if (_fireAction != null && _fireAction > _leftAction)
                        {
                            _model.FireShot();
                        }
                        else
                        {
                            _model.MovePlayer(Direction.Right);
                        }
                    }
                }
                else if (_leftAction != null)
                {
                    _model.MovePlayer(Direction.Left);
                }
                else if (_rightAction != null)
                {
                    _model.MovePlayer(Direction.Right);
                }
                else if (_fireAction != null)
                {
                    _model.FireShot();
                }
            }

            _model.Update(Paused);


            // Update score
            if (Score != _model.Score)
            {
                Score = _model.Score;
                OnPropertyChanged("Score");
            }

            // Update lives
            if (_lives.Count > _model.Lives)
            {
                _lives.RemoveAt(_lives.Count - 1);
                if (_lives.Count == 0)
                {
                    EndGame();
                }
            }
            else if (_lives.Count < _model.Lives)
            {
                _lives.Add(new object());
            }
            OnPropertyChanged("Lives");

            // Remove dead invaders who have finished fading out
            foreach (FrameworkElement control in _shotInvaders.Keys.ToList())
            {
                DateTime invaderDiedTime = _shotInvaders[control];
                TimeSpan timeSinceInvaderDied = DateTime.Now - invaderDiedTime;
                if (timeSinceInvaderDied > _timeLimitInvadersFadeoutSeconds)
                {
                    _sprites.Remove(control);
                    _shotInvaders.Remove(control);
                }
            }

            if (GameOver)
            {
                OnPropertyChanged("GameOver");
                _timer.Stop();
            }
        }

        private void ModelShipChangedEventHandler(object sender, ShipChangedEventArgs e)
        {
            if (!e.Killed)
            {
                if (e.ShipUpdated is Invader)
                {
                    Invader invader = e.ShipUpdated as Invader;

                    if (!_invaders.ContainsKey(invader))
                    {
                        FrameworkElement invaderControl = InvadersHelper.InvaderFactory((int)invader.InvaderType, 
                                                                                        invader.Size.Width, 
                                                                                        invader.Size.Height,
                                                                                        Scale,
                                                                                        _timer.Interval);
                        _sprites.Add(invaderControl);
                        _invaders.Add(invader, invaderControl);
                        InvadersHelper.SetCanvasLocation(invaderControl, 
                                                            invader.Location.X, 
                                                            invader.Location.Y, 
                                                            Scale);
                    }
                    else
                    {
                        FrameworkElement invaderControl = _invaders[invader];
                        InvadersHelper.MoveElementOnCanvas(invaderControl, 
                                                            invader.Location.X, 
                                                            invader.Location.Y,
                                                            Scale);
                        InvadersHelper.ResizeElement((AnimatedImage)invaderControl,
                                                     invader.Size.Width,
                                                     invader.Size.Height,
                                                     Scale);
                    }
                }
                else if (e.ShipUpdated is Player)
                {
                    Player player = e.ShipUpdated as Player;

                    if (_playerFlashing && !_model.PlayerDying)
                    {
                        _playerFlashing = false;
                        AnimatedImage playerControl = (AnimatedImage)_playerControl;
                        playerControl.StopFlashing();
                    }

                    if (_playerControl == null)
                    {
                        _playerControl = InvadersHelper.PlayerFactory(player.Size.Width, 
                                                                        player.Size.Height, 
                                                                        Scale, 
                                                                        _timer.Interval);
                        _sprites.Add(_playerControl);
                        InvadersHelper.SetCanvasLocation(_playerControl, 
                                                            player.Location.X, 
                                                            player.Location.Y, 
                                                            Scale);
                    }
                    else
                    {
                        InvadersHelper.MoveElementOnCanvas(_playerControl, 
                                                            player.Location.X, 
                                                            player.Location.Y,
                                                            Scale);
                        InvadersHelper.ResizeElement((AnimatedImage)_playerControl,
                                                        player.Size.Width,
                                                        player.Size.Height,
                                                        Scale);
                    }
                }
            }
            else
            {
                // Invader killed
                if (e.ShipUpdated is Invader)
                {
                    Invader invader = e.ShipUpdated as Invader;

                    if (_invaders.ContainsKey(invader))
                    {
                        AnimatedImage invaderControl = (AnimatedImage)_invaders[invader];

                        invaderControl.InvaderShot(_timeLimitInvadersFadeoutSeconds);
                        _shotInvaders.Add(invaderControl, DateTime.Now);
                        _invaders.Remove(invader);
                    }
                }
                // Player killed
                else if (e.ShipUpdated is Player)
                {
                    Player player = e.ShipUpdated as Player;
                    AnimatedImage playerControl = (AnimatedImage)_playerControl;
                    playerControl.StartFlashing();
                    _playerFlashing = true;
                }
            }
        }

        private void ModelShotMovedEventHandler(object sender, ShotMovedEventArgs e)
        {
            if (!e.Disappeared)
            {
                if (!_shots.ContainsKey(e.Shot))
                {
                    FrameworkElement shotControl = InvadersHelper.ShotFactory(Shot.ShotSize.Width, 
                                                                                Shot.ShotSize.Height, 
                                                                                Scale,
                                                                                _timer.Interval);
                    InvadersHelper.SetCanvasLocation(shotControl, 
                                                        e.Shot.Location.X, 
                                                        e.Shot.Location.Y,
                                                        Scale);
                    _shots.Add(e.Shot, shotControl);
                    _sprites.Add(shotControl);
                }
                else
                {
                    FrameworkElement shotControl = _shots[e.Shot];
                    InvadersHelper.MoveElementOnCanvas(shotControl, 
                                                        e.Shot.Location.X, 
                                                        e.Shot.Location.Y, 
                                                        Scale);
                }
            }
            else if(_shots.ContainsKey(e.Shot))
            {
                FrameworkElement shotControl = _shots[e.Shot];
                _sprites.Remove(shotControl);
            }
        }

        private void ModelStarChangedEventHandler(object sender, StarChangedEventArgs e)
        {
            if (e.Disappeared && _stars.ContainsKey(e.Point))
            {
                FrameworkElement control = _stars[e.Point];
                _sprites.Remove(control);
            }
            else 
            {
                if (!_stars.ContainsKey(e.Point))
                {
                    FrameworkElement starControl = InvadersHelper.StarControlFactory(Scale);
                    InvadersHelper.SendToBack(starControl);
                    _stars.Add(e.Point, starControl);
                    _sprites.Add(starControl);
                    InvadersHelper.SetCanvasLocation(starControl, e.Point.X, e.Point.Y, Scale);
                }
                else
                {
                    // Create a shooting star
                    FrameworkElement starControl = _stars[e.Point];
                    InvadersHelper.MoveElementOnCanvas(starControl,
                                                        InvadersModel.PlayAreaSize.Width,
                                                        InvadersModel.PlayAreaSize.Height,
                                                        Scale);
                }
                    
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
