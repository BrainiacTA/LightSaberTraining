namespace LightSaberGame.ViewModels
{
    using BaseViewModels;
    using LightSaberGame.Data;
    using LightSaberGame.Extensions;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class HighScoresPageViewModes : BaseViewModel
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

                foreach (var item in value)
                {
                    this.heroes.Add(item);
                }
            }
        }

        public HighScoresPageViewModes(IData data)
        {
            this.data = data;
            this.Refresh();
        }

        private async void Refresh()
        {
            var data = await this.data.GetHeroes();
            var list = new List<HeroViewModel>();
            foreach (var item in data)
            {
                list.Add(new HeroViewModel(item.Name, item.Score));
            }
            //var heroes = data.Select(m => new HeroViewModel(m.Name, m.Score));
            this.Heroes = list;
        }

    }
}
