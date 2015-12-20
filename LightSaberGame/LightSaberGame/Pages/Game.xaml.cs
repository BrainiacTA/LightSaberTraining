namespace LightSaberGame.Pages
{
    using Extensions;
    using Helpers.GameHelpers;
    using LightSaberGame.ViewModels;
    using LightSaberGame.ViewModels.GameObjectsViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Windows.Devices.Geolocation;
    using Windows.Devices.Sensors;
    using Windows.Foundation;
    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Media;
    using Windows.UI;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        private Accelerometer accelerometer;
        private Geolocator geoLocator;
        private double scoreMultyplier = 1;
        private readonly Random rng;
        private bool hasBackgorund = false;

        public Game()
        {
            this.InitializeComponent();
            this.DataContext = new GameViewModel();

            //get city

            this.geoLocator = new Geolocator();
            this.geoLocator.PositionChanged += Location;
            //var s = this.Location().Result;

            this.rng = new Random();

            var viewModel = this.DataContext as GameViewModel;

            this.AccelerometerSetUp();
            this.Spawing(viewModel);
            this.Physics(viewModel);
        }

        private async void Location(Geolocator sender, PositionChangedEventArgs args)
        {
            if(this.hasBackgorund)
            {
                return;
            }

            var longitude = args.Position.Coordinate.Longitude;

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if ((int)longitude % 2 == 0)
                {
                    this.Health.Text = "Blue";
                    this.cnv1.Background = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    this.cnv1.Background = new SolidColorBrush(Colors.Red);
                }
            });
           
            this.hasBackgorund = true;
        }


        private void AccelerometerSetUp()
        {
            this.accelerometer = Accelerometer.GetDefault();
            this.accelerometer.ReportInterval = 50;
            this.accelerometer.ReadingChanged += new TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(ReadingChanged);
        }

        private void Physics(GameViewModel viewModel)
        {
            var physicsTimer = new DispatcherTimer();
            physicsTimer.Interval = TimeSpan.FromMilliseconds(100);
            physicsTimer.Tick += (snd, arg) =>
            {
                var shotsToCheck = viewModel.Shots
                .Where(z => z.Distance >= 0 && z.Distance <= 1)
                .ToList();

                viewModel.Health = 100 - viewModel.Shots.Count(z => z.Distance < 0) * 10;
                if (shotsToCheck.Count == 0)
                {
                    return;
                }

                if (!saber.SwitchedOn)
                {
                    return;
                }

                var toDelete = new List<ShotViewModel>();
                foreach (var item in shotsToCheck)
                {
                    if (GameObjectViewModel.ObjectsCollided(viewModel.LightSaber, item))
                    {
                        toDelete.Add(item);
                    }
                }

                if (toDelete.Count > 0)
                {
                    this.HitSound.Play();
                    viewModel.Score += 10 * scoreMultyplier;
                }
                toDelete.ForEach(viewModel.RemoveShot);

                //viewModel.Health = 100 -viewModel.Shots.Count(z => z.Distance < 0)*10;
                scoreMultyplier += 0.2;
            };
            physicsTimer.Start();
        }

        private void Spawing(GameViewModel viewModel)
        {
            var spawnTimer = new DispatcherTimer();
            var spawnInterval = 2000;
            spawnTimer.Interval = TimeSpan.FromMilliseconds(spawnInterval);
            spawnTimer.Tick += (snd, arg) =>
            {
                var x = 100 + this.rng.NextDouble() * 200;
                var y = 100 + this.rng.NextDouble() * 200;
                var r = 30;
                viewModel.AddShot(x, y, r);
                if (spawnInterval > 750)
                {
                    spawnInterval -= 100;
                    spawnTimer.Interval = TimeSpan.FromMilliseconds(spawnInterval);
                }
            };
            spawnTimer.Start();
        }

        async private void ReadingChanged(object Accelerometer, AccelerometerReadingChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var viewModel = this.DataContext as GameViewModel;

                AccelerometerReading reading = e.Reading;

                var x = reading.AccelerationX;
                var y = reading.AccelerationY;
                var z = reading.AccelerationZ;

                var newAngel = -Math.Atan2(-x, Math.Sqrt(y * y + z * z)) * (180 / Math.PI);

                if (Math.Abs(newAngel - viewModel.LightSaber.Angle) >= 10)
                {
                    viewModel.LightSaber.Angle = newAngel;
                    this.MoveSound.Play();
                }

            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModeld = this.DataContext as GameViewModel;
            viewModeld.LightSaber.Angle += 30;
        }

        private void SaberMove(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var delta = e.Delta;

            var x = delta.Translation.X;
            var y = delta.Translation.Y;

            var viewModeld = this.DataContext as GameViewModel;
            if (viewModeld.LightSaber.Left + x < 0)
            { return; }
            viewModeld.LightSaber.Top += y;
            viewModeld.LightSaber.Left += x;
            this.scoreMultyplier = 1;
            
        }

        private void saber_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            this.MoveSound.Play();
        }

        private void saber_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
        }

        private void SaberStopInertia(object sender, ManipulationInertiaStartingRoutedEventArgs e)
        {
            e.TranslationBehavior.DesiredDeceleration = 100;
        }

        private void ForcePushOnDoubleTap(object sender, DoubleTappedRoutedEventArgs e)
        {
            var location = e.GetPosition(sender as UIElement);

            var viewModel = this.DataContext as GameViewModel;
            var shots = viewModel.Shots;

            var range = 50;

            var shotTargeted = viewModel.Shots
                .Where(z => Math.Abs(z.Left - location.X) <= range &&
                             Math.Abs(z.Top - location.Y) <= range)
                .ToList();

            var shotss = shotTargeted;

            shotTargeted.ForEach(viewModel.RemoveShot);

        }
    }
}
