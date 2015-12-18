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
            this.Diameter = r;
        }

        public double Diameter
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
            var centerX = this.Left - this.Diameter / 2;
            collisionsPoints.Add(new CollisionCircle(this.Top, this.Left, this.Diameter/2));

            return collisionsPoints;
        }
    }
}
