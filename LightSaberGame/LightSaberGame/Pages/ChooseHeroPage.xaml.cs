namespace LightSaberGame.Pages
{
    using LightSaberGame.ViewModels;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChooseHeroPage : Page
    {
        public ChooseHeroPage()
        {
            this.InitializeComponent();
            this.DataContext = new HeroPickPageViewModel();
        }
    }
}
