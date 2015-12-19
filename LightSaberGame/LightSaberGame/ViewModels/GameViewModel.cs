using LightSaberGame.ViewModels.GameObjectsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSaberGame.ViewModels
{
    public class GameViewModel
    {
        public GameViewModel()
        {
            this.LightSaber = new LightSaberViewModel();
        }
        public LightSaberViewModel LightSaber { get; set; }
    }
}
