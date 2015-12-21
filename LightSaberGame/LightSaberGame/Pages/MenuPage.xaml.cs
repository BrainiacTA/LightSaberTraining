using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LightSaberGame.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuPage : Page
    {
        public MenuPage()
        {
            this.InitializeComponent();
        }

        private void OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Game), e);
        }

        private void OnHighScoresButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HighScoresPage), e);
        }

        private void OnExitButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EnterScorePage), 10.0);
            //CoreApplication.Exit();
        }
    }
}
