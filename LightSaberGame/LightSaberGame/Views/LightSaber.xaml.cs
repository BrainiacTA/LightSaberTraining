using LightSaberGame.Extensions;
using LightSaberGame.ViewModels.GameObjectsViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace LightSaberGame.Views
{
    public sealed partial class LightSaber : UserControl
    {
        public bool SwitchedOn
        {
            get { return (bool)GetValue(SwitchedOnProperty); }
            set { SetValue(SwitchedOnProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SwitchedOn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SwitchedOnProperty =
            DependencyProperty.Register("SwitchedOn", typeof(bool), typeof(LightSaber), new PropertyMetadata(true));

        public double BladeLenght
        {
            get { return (double)GetValue(BladeLenghtProperty); }
            set { SetValue(BladeLenghtProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BladeLenght.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BladeLenghtProperty =
            DependencyProperty.Register("BladeLenght", typeof(double), typeof(LightSaber), new PropertyMetadata(250));

        
        public LightSaber()
        {
            this.InitializeComponent();
            //this.soundOn.Play();
            //this.DataContext = new LightSaberViewModel();
        }
        private void SwitchOn(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (!this.SwitchedOn)
            {
                this.soundSwitchOn.Play();
                this.soundOn.Play();
            }
            else
            {
                this.soundSwitchOff.Play();
                this.soundOn.Stop();
            }
            var oldValue = AnimationProperties.GetExtended(this.blade);
            AnimationProperties.SetExtended(this.blade, !oldValue);
            this.SwitchedOn = !this.SwitchedOn;

        }

        //private void hilt_Holding(object sender, HoldingRoutedEventArgs e)
        //{
        //    if (!this.SwitchedOn)
        //    {
        //        this.soundSwitchOn.Play();
        //        this.soundOn.Play();
        //    }
        //    else
        //    {
        //        this.soundSwitchOff.Play();
        //        this.soundOn.Stop();
        //    }
        //    var oldValue = AnimationProperties.GetExtended(this.blade);
        //    AnimationProperties.SetExtended(this.blade, !oldValue);
        //    this.SwitchedOn = !this.SwitchedOn;
        //}
    }
}
