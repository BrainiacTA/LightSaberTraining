namespace LightSaberGame.Helpers.GameHelpers
{
    using System;

    public class CollisionCircle
    {
        public static bool CirclesCollide(CollisionCircle c1, CollisionCircle c2)
        {
            var xDist = Math.Abs(c1.X - c2.X);
            var yDist = Math.Abs(c1.Y - c2.Y);
            var touchDist = c1.R + c2.R;

            if ((xDist+yDist) * (xDist + yDist) > touchDist * touchDist)
            {
                return false;
            }

            return true;
        }
        public CollisionCircle(double x, double y, double r)
        {
            this.X = x;
            this.Y = y;
            this.R = r;
        }
        public double X { get; set; }

        public double Y { get; set; }

        public double R { get; set; }
    }
}
