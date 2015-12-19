using LightSaberGame.Extensions;
using LightSaberGame.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LightSaberGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Accelerometer accelerometer;

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new GameViewModel();

            this.accelerometer = Accelerometer.GetDefault();
            this.accelerometer.ReportInterval = 50;
            this.accelerometer.ReadingChanged += new TypedEventHandler<Accelerometer, AccelerometerReadingChangedEventArgs>(ReadingChanged);

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(5000);
            var viewModel = this.DataContext as GameViewModel;
            var rng = new Random();
            double x, y;
            double r = 30;
            timer.Tick += (snd, arg) =>
            {
                x = 100 + rng.NextDouble() * 200;
                viewModel.AddShot(x, x, r);
            };
            timer.Start();
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
            if(viewModeld.LightSaber.Left + x <0)
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
