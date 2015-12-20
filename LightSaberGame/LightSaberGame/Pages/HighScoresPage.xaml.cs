using LightSaberGame.Data;
using LightSaberGame.ViewModels.BaseViewModels;
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


namespace LightSaberGame.Pages
{
    public sealed partial class HighScoresPage : Page
    {
        public HighScoresPage()
        {
            this.InitializeComponent();

            this.ViewModel = new HighScoresPageViewModes(new HttpServerData("http://api.everlive.com/v1/ORRJBaNvaz3yxDgP/Hero"));
            this.ViewModel.Heroes = new List<HeroViewModel>();
        }

        public HighScoresPageViewModes ViewModel
        {
            get
            {
                return this.DataContext as HighScoresPageViewModes;
            }
            set
            {
                this.DataContext = value;
            }

        }

        private void OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Game), e);
        }

        private void OnQuitButtonClick(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(Game), e);
        }
    }
}
