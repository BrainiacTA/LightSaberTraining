namespace LightSaberGame.ViewModels
{
    using LightSaberGame.Data;
    using LightSaberGame.Extensions;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class HighScoresPageViewModes
    {
        private ObservableCollection<HeroViewModel> heroes;
        private IData data;

        public IEnumerable<HeroViewModel> Heroes
        {
            get
            {
                if (this.heroes == null)
                {
                    this.heroes = new ObservableCollection<HeroViewModel>();
                }
                return this.heroes;
            }
            set
            {
                if (this.heroes == null)
                {
                    this.heroes = new ObservableCollection<HeroViewModel>();
                }
                this.heroes.Clear();

                value.ForEach(heroes.Add);
            }
        }

        public HighScoresPageViewModes(IData data)
        {
            this.data = data;
            this.Refresh();
        }

        private async void Refresh()
        {
            this.Heroes = (await this.data.GetHeroes())
                                        .Select(m => new HeroViewModel(m.Name, m.Score));
        }

    }
}
