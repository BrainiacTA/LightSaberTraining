namespace LightSaberGame.ViewModels.GameObjectsViewModels
{
    using System.Collections.Generic;
    using Helpers.GameHelpers;

    public class ShotViewModel : GameObjectViewModel
    {
        private double radius;

        public ShotViewModel(double t, double l, double r)
            : base(t, l)
        {
            this.Radius = r;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                this.radius = value;
                this.OnPropertyChanged("Radius");
            }
        }

        public override IEnumerable<CollisionCircle> GetCollisionInfo()
        {
            var collisionsPoints = new List<CollisionCircle>();

            collisionsPoints.Add(new CollisionCircle(this.Top, this.Left, this.Radius));

            return collisionsPoints;
        }
    }
}
