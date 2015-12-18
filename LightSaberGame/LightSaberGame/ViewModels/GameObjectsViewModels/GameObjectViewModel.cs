namespace LightSaberGame.ViewModels.GameObjectsViewModels
{
    using System.Collections.Generic;

    using BaseViewModels;
    using Helpers.GameHelpers;
    public abstract class GameObjectViewModel : BaseViewModel
    {
        private double top;
        private double left;

        public GameObjectViewModel(double t, double l)
        {
            this.Top = t;
            this.Left = l;
        }
        public double Top
        {
            get
            {
                return this.top;
            }
            set
            {
                this.top = value;
                this.OnPropertyChanged("Top");
            }
        }

        public double Left
        {
            get
            {
                return this.left;
            }
            set
            {
                this.left = value;
                this.OnPropertyChanged("Left");
            }
        }

        public virtual IEnumerable<CollisionCircle> GetCollisionInfo()
        {
            return null;
        }
    }
}
