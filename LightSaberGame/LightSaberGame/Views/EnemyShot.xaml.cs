namespace LightSaberGame.Views
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    public sealed partial class EnemyShot : UserControl
    {



        public double Distance
        {
            get { return (double)GetValue(DistanceProperty); }
            set { SetValue(DistanceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Distance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DistanceProperty =
            DependencyProperty.Register("Distance", typeof(double), typeof(EnemyShot), new PropertyMetadata(3.0));


        public double Diameter
        {
            get { return (double)GetValue(DiameterProperty); }
            set { SetValue(DiameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Radius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DiameterProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(EnemyShot), new PropertyMetadata(30.0));


        public EnemyShot()
        {
            this.InitializeComponent();
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += (snd, args) =>
            {
               
                this.Distance -= 1.0;
                this.tbTimer.Text = this.Distance.ToString();
                // this.btnTimer.Content = this.Distance.ToString();
                if (Distance < 0)
                {
                    this.Visibility = Visibility.Collapsed;
                    timer.Stop();
                }
            };
            timer.Start();
        }

        private void Grid_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
