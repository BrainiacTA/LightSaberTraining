using LightSaberGame.Extensions;
using LightSaberGame.ViewModels.BaseViewModels;
using LightSaberGame.ViewModels.GameObjectsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSaberGame.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private LightSaberViewModel ligthSaber;
        private double score;
        private ObservableCollection<ShotViewModel> shots;
        private double health;
        private string background;

        public GameViewModel()
        {
            this.LightSaber = new LightSaberViewModel(100,300,250,30);
            this.Health = 100;
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

        public double Score
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

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
                this.OnPropertyChanged("Health");
            }
        }

        public string Background
        {
            get
            {
                return this.background;
            }
            set
            {
                this.background = value;
                this.OnPropertyChanged("Background");
            }
        }

        public IEnumerable<ShotViewModel> Shots
        {
            get
            {
                if(this.shots == null)
                {
                    this.shots = new ObservableCollection<ShotViewModel>();
                }
                return this.shots;
            }
            set
            {
                if (this.shots == null)
                {
                    this.shots = new ObservableCollection<ShotViewModel>();
                }
                this.shots.Clear();

                value.ForEach(this.shots.Add);
            }
        }


        public void AddShot (double x, double y, double r)
        {
            var shot = new ShotViewModel(x, y, r,3);
            this.shots.Add(shot);
        }

        public void RemoveShot( ShotViewModel shot)
        {
            this.shots.Remove(shot);
        }




    }
}
