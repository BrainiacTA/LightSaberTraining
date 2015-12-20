﻿namespace LightSaberGame.Pages
{
    using LightSaberGame.ViewModels;
    using LightSaberGame.ViewModels.GameObjectsViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Windows.Devices.Sensors;
    using Windows.Foundation;
    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        private Accelerometer accelerometer;

        public Game()
        {
            this.InitializeComponent();
            this.DataContext = new GameViewModel();

            this.accelerometer = Accelerometer.GetDefault();
            this.accelerometer.ReportInterval = 50;
            this.accelerometer.ReadingChanged += new TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(ReadingChanged);

            var spawnTimer = new DispatcherTimer();
            spawnTimer.Interval = TimeSpan.FromMilliseconds(2000);
            var viewModel = this.DataContext as GameViewModel;
            var rng = new Random();
            double x, y;
            double r = 30;
            spawnTimer.Tick += (snd, arg) =>
            {
                x = 100 + rng.NextDouble() * 200;
                viewModel.AddShot(x, x, r);
            };
            spawnTimer.Start();


            var physicsTimer = new DispatcherTimer();
            physicsTimer.Interval = TimeSpan.FromMilliseconds(100);
            physicsTimer.Tick += (snd, arg) =>
            {
                var shotsToCheck = viewModel.Shots
                .Where(z => z.Distance >= 0 && z.Distance <= 1)
                .ToList();
                if (shotsToCheck.Count == 0)
                {
                    return;
                }

                var bladePoints = viewModel.LightSaber.GetCollisionInfo();
                var toDelete = new List<ShotViewModel>();
                foreach (var item in shotsToCheck)
                {
                    if (GameObjectViewModel.ObjectsCollided(viewModel.LightSaber, item))
                    {
                        toDelete.Add(item);
                    }
                }

                toDelete.ForEach(viewModel.RemoveShot);
            };
            physicsTimer.Start();
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

                var newAngel = Math.Atan2(-x, Math.Sqrt(y * y + z * z)) * (180 / Math.PI);

                if (Math.Abs(newAngel - viewModel.LightSaber.Angle) >= 10)
                {
                    viewModel.LightSaber.Angle = newAngel;
                }

            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModeld = this.DataContext as GameViewModel;
            viewModeld.LightSaber.Angle += 30;
        }

        private void saber_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var delta = e.Delta;

            var x = delta.Translation.X;
            var y = delta.Translation.Y;

            var viewModeld = this.DataContext as GameViewModel;
            if (viewModeld.LightSaber.Left + x < 0)
            { return; }
            viewModeld.LightSaber.Top += y;
            viewModeld.LightSaber.Left += x;
        }

        private void saber_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
        }

        private void saber_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {

        }

        private void saber_ManipulationInertiaStarting(object sender, ManipulationInertiaStartingRoutedEventArgs e)
        {
            e.TranslationBehavior.DesiredDeceleration = 100;
        }
    }
}