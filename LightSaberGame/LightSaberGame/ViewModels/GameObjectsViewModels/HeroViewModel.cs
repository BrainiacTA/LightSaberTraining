using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSaberGame.ViewModels.GameObjectsViewModels
{
    public class HeroViewModel
    {
        public HeroViewModel()
            : this(string.Empty, string.Empty)
        {

        }

        public HeroViewModel(string name, string score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name { get; set; }

        public string Score { get; set; }
    }
}
