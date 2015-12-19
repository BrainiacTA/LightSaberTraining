namespace LightSaberGame.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.Foundation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Media;
    public class AnimationProperties
    {



        public static bool GetExtended(DependencyObject obj)
        {
            return (bool)obj.GetValue(ExtendedProperty);
        }

        public static void SetExtended(DependencyObject obj, bool value)
        {
            obj.SetValue(ExtendedProperty, value);
        }

        // Using a DependencyProperty as the backing store for Extended.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExtendedProperty =
            DependencyProperty.RegisterAttached("Extended", typeof(bool), typeof(UIElement), new PropertyMetadata(false, ExtendedCallBack));

        private static void ExtendedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //validation and casting
            var element = d as UIElement;

            if (element==null)
            {
                return;
            }

            // create transfrom
            element.RenderTransform = new ScaleTransform();
            element.RenderTransformOrigin = new Point(1, 1);
            var transform = element.RenderTransform as ScaleTransform;

            //set static values
            var oldValue = (bool)e.OldValue;
            var newValue = (bool)e.NewValue;
            var animationEffect = 0.01;

            //determine starting point
            double staringPoint = 1;
            if(oldValue)
            {
                staringPoint = 0;
            }

            transform.ScaleY = staringPoint;
            
            //Set up timer
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(5);

            //animation behavior
            timer.Tick += (snd, args) =>
            {
                if(oldValue == newValue)
                {
                    return;
                }

                if (newValue)
                {
                    transform.ScaleY -= animationEffect;
                }
                else
                {
                    transform.ScaleY += animationEffect;
                }

                //end condition
                if(transform.ScaleY<=0|| transform.ScaleY>=1)
                {
                    timer.Stop();
                    return;
                }
            };
            timer.Start();
        }
    }
}
