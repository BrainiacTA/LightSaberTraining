using LightSaberGame.ViewModels.BaseViewModels;
using LightSaberGame.ViewModels.GameObjectsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSaberGame.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private LightSaberViewModel ligthSaber;

        public GameViewModel()
        {
            this.LightSaber = new LightSaberViewModel(100,300,250,0);
        }
        public LightSaberViewModel LightSaber
        {
            get
            {
                return this.ligthSaber;
            }
            set
            {
                this.ligthSaber = value;
                this.OnPropertyChanged("LightSaber");
            }
        }
    }
}
