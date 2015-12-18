﻿namespace LightSaberGame.ViewModels.GameObjectsViewModels
{

    using System;
    using System.Collections.Generic;

    using Helpers.GameHelpers;
    public class LightSaberViewModel : GameObjectViewModel
    {
        private double length;
        private double angle;

        public LightSaberViewModel(double l, double t, double length, double a)
            : base(l, t)
        {
            this.Length = length;
            this.Angle = a;
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
            var startX = this.Left - (this.Length + this.Width) * sin;
            var startY = this.Top + this.Length * (1 - cos);

            var segment = this.Length / 10;
            for (int i = 0; i < 10; i++)
            {
                var left = startX + i * segment * sin;
                var top = startY + i * segment * cos;
                var r = segment / 2;
                collisionPoints.Add(new CollisionCircle(left, top, r));
            }
            return collisionPoints;
        }
    }
}