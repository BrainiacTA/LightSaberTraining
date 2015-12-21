namespace LightSaberGame.ViewModels
{
    using LightSaberGame.ViewModels.BaseViewModels;

    public class HeroViewModel : BaseViewModel
    {
        private string name;
        private int score;

        public HeroViewModel()
        {
            this.Name = string.Empty;
            this.score = 0;
        }

        public HeroViewModel(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
                this.OnPropertyChanged("Score");
            }
        }
    }
}
