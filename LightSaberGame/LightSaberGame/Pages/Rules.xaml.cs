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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LightSaberGame.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Rules : Page
    {
        public Rules()
        {
            this.InitializeComponent();
        }

        private void ScrollViewer_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var scale = e.Delta.Scale;

            this.Content.FontSize *= scale;

            var delty = -e.Delta.Translation.Y;

            var currentOffset = this.Scroller.VerticalOffset;
            this.Scroller.ScrollToVerticalOffset(currentOffset + delty*5);
        }

        private void Content_Holding(object sender, HoldingRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }
    }
}
