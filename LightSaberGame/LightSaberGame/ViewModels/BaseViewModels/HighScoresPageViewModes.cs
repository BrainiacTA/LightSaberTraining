using LightSaberGame.Data;
using LightSaberGame.ViewModels.GameObjectsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSaberGame.ViewModels.BaseViewModels
{
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
            this.Heroes = (await this.data.GetHeroes())
                                        .Select(m => new HeroViewModel(m.Name, m.Score));
        }
    }
}
