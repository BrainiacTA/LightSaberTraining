﻿namespace LightSaberGame.ViewModels.GameObjectsViewModels
{

    using System;
    using System.Collections.Generic;

    using Helpers.GameHelpers;
    public class LightSaberViewModel : GameObjectViewModel
    {
        private double length;
        private double angle;

        public LightSaberViewModel(double left, double top, double length, double angle)
            : base(left, top)
        {
            this.Length = length;
            this.Angle = angle;
        }
        public LightSaberViewModel()
            : base(0, 0)
        {
            this.Length = 250;
            this.Angle = 0;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            set
            {
                this.length = value;
                this.OnPropertyChanged("Lenght");
            }
        }

        public double Width
        {
            get
            {
                return this.Length / 10;
            }
        }

        public double Angle
        {
            get
            {
                return this.angle;
            }
            set
            {
                this.angle = value;
                this.OnPropertyChanged("Angle");
            }
        }

        public override IEnumerable<CollisionCircle> GetCollisionInfo()
        {
            var collisionPoints = new List<CollisionCircle>();
            var angle = Math.PI * this.Angle / 180;
            var sin = Math.Sin(angle);
            var cos = Math.Cos(angle);

            var segment = this.Length / 10;
            var startX = this.Left + (this.Length + segment) * sin;
            var startY = this.Top + (this.Length + segment) * (1 - cos);

            for (int i = 0; i < 10; i++)
            {
                var r = segment / 2;
                var left = startX - i * r * sin;
                var top = startY + i * segment * cos;
                collisionPoints.Add(new CollisionCircle(left, top, r));
            }
            return collisionPoints;
        }
    }
}
