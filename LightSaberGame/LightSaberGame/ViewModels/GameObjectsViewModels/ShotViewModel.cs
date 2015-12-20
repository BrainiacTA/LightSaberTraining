namespace LightSaberGame.ViewModels.GameObjectsViewModels
{
    using System.Collections.Generic;
    using Helpers.GameHelpers;

    public class ShotViewModel : GameObjectViewModel
    {
        private double radius;
        private double distance;

        public ShotViewModel(double left, double top, double radius, double distance)
            : base(left, top)
        {
            this.Diameter = radius;
            this.Distance = distance;
        }

        public double Distance
        {
            get
            {
                return this.distance;
            }
            set
            {
                this.distance = value;
                this.OnPropertyChanged("Distance");
            }
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
            var centerX = this.Left + this.Diameter / 2;
            var centerY = this.Top + this.Diameter / 2;
            collisionsPoints.Add(new CollisionCircle(centerX, centerY, this.Diameter/2));

            return collisionsPoints;
        }
    }
}
