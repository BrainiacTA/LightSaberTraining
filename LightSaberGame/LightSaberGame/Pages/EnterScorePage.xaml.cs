using LightSaberGame.Model.SQLLite;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class EnterScorePage : Page
    {
        private double score = 0;
        public EnterScorePage()
        {
            this.InitializeComponent();
            this.InitAsync();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.score = (double)e.Parameter;
            this.Score.Text = score.ToString();

            var isHighScore = await this.CheckForHighScore();
            if(isHighScore)
            {
                this.Score.Text += Environment.NewLine + "New HighScore";
            }

        }

        private async void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            var item = new ScoreModel
            {
                Name = this.tbUsername.Text,
                Score = this.score
            };

            await this.InsertUserAsync(item);

            this.Frame.Navigate(typeof(MenuPage));
        }

        //private async void AddNewItemButtonClick(object sender, RoutedEventArgs e)
        //{
        //    var price = 0;
        //    int.TryParse(this.PriceTextBox.Text, out price);
        //    var item = new UserItem
        //    {
        //        Name = this.NameTextBox.Text,
        //        Price = price
        //    };

        //    await this.InsertUserAsync(item);
        //}

        private async Task<bool> CheckForHighScore()
        {
            var userData = await this.GetAllUserAsync();

            var isHighScore = userData.Any(z => z.Score >= this.score);

            return !isHighScore;
        }

        private SQLiteAsyncConnection GetDbConnectionAsync()
        {
            var dbFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite");

            var connectionFactory =
                new Func<SQLiteConnectionWithLock>(
                    () =>
                    new SQLiteConnectionWithLock(
                        new SQLitePlatformWinRT(),
                        new SQLiteConnectionString(dbFilePath, storeDateTimeAsTicks: false)));

            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);

            return asyncConnection;
        }

        private async void InitAsync()
        {
            var connection = this.GetDbConnectionAsync();
            var table = connection.Table<ScoreModel>();
            if (table == null)
            {
                await connection.CreateTableAsync<ScoreModel>();
            }
        }

        private async Task<int> InsertUserAsync(ScoreModel item)
        {
            var connection = this.GetDbConnectionAsync();
            var result = await connection.InsertAsync(item);
            return result;
        }

        private async Task<List<ScoreModel>> GetAllUserAsync()
        {
            var connection = this.GetDbConnectionAsync();
            var result = await connection.Table<ScoreModel>().ToListAsync();
            return result;
        }
    }
}
