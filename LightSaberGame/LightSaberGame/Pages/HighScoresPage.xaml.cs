namespace LightSaberGame.Pages
{
    using LightSaberGame.Data;
    using LightSaberGame.ViewModels;
    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

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
