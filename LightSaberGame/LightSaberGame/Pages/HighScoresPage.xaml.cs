namespace LightSaberGame.Pages
{
    using LightSaberGame.Data;
    using LightSaberGame.ViewModels;
    using System.Collections.Generic;
    using Windows.ApplicationModel.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class HighScoresPage : Page
    {
        public HighScoresPage()
        {
            this.InitializeComponent();
            this.DataContext = new HighScoresPageViewModes(new HttpServerData("http://api.everlive.com/v1/ORRJBaNvaz3yxDgP/Hero"));
            //this.ViewModel = new HighScoresPageViewModes(new HttpServerData("http://api.everlive.com/v1/ORRJBaNvaz3yxDgP/Hero"));
            //this.ViewModel.Heroes = new List<HeroViewModel>();
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

        private void OnHPlayButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Game), null);
        }

        private void OnHExitButtonClick(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }
    }
}
