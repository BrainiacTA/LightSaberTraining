namespace LightSaberGame.ViewModels.GameObjectsViewModels
{
    using System.Collections.Generic;

    using BaseViewModels;
    using Helpers.GameHelpers;
    public abstract class GameObjectViewModel : BaseViewModel
    {
        private double top;
        private double left;

        public static bool ObjectsCollided(GameObjectViewModel obj1, GameObjectViewModel obj2)
        {
            var collided = false;

            foreach (var point1 in obj1.GetCollisionInfo())
            {
                foreach (var point2 in obj2.GetCollisionInfo())
                {
                    if (CollisionCircle.CirclesCollide(point1, point2))
                    {
                        collided = true;
                        break;
                    }
                }
            }

            return collided;
        }
        public GameObjectViewModel(double left, double top)
        {
            this.Top = top;
            this.Left = left;
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
