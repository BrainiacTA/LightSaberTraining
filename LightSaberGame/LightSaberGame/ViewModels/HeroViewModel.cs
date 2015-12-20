namespace LightSaberGame.ViewModels
{
    using LightSaberGame.ViewModels.BaseViewModels;
    public class HeroViewModel : BaseViewModel
    {
        private string name;
        private string score;

        public HeroViewModel()
        {
            this.Name = string.Empty;
            this.score = string.Empty;
        }

        public HeroViewModel(string name, string score)
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

        public string Score
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
