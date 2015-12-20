namespace LightSaberGame.ViewModels
{
    using LightSaberGame.Extensions;
    using LightSaberGame.ViewModels.BaseViewModels;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Windows.UI.Xaml.Media.Imaging;

    public class HeroPickPageViewModel : BaseViewModel
    {
        private double size;
        private ObservableCollection<BitmapImage> imageSources;

        public HeroPickPageViewModel()
        {
            this.Size = 100;

            this.InitImageCollection();
        }

        private void InitImageCollection()
        {
            var images = new List<BitmapImage>();
            images.Add(new BitmapImage(new Uri("https://s-media-cache-ak0.pinimg.com/originals/ec/40/31/ec40312a4bfeceda9d6293f8bcc575bb.jpg")));
            images.Add(new BitmapImage(new Uri("http://media.melty.fr/article-1312882-ajust_930/luke-skywalker.jpg")));
            images.Add(new BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/en/6/6d/Chewbacca-2-.jpg")));
            images.Add(new BitmapImage(new Uri("http://www.modelosaescala.com/wp-content/uploads/2009/12/starwars-r2d2.01.jpg")));


            this.ImageSources = images;
            //{
            //    @"https://s-media-cache-ak0.pinimg.com/originals/ec/40/31/ec40312a4bfeceda9d6293f8bcc575bb.jpg",
            //    @"http://media.melty.fr/article-1312882-ajust_930/luke-skywalker.jpg",
            //    @"https://upload.wikimedia.org/wikipedia/en/6/6d/Chewbacca-2-.jpg",
            //    @"http://www.modelosaescala.com/wp-content/uploads/2009/12/starwars-r2d2.01.jpg"
            //};

        }

        public double Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
                this.OnPropertyChanged("Size");
            }

        }

        public IEnumerable<BitmapImage> ImageSources
        {
            get
            {
                if(this.imageSources == null)
                {
                    this.imageSources = new ObservableCollection<BitmapImage>();
                }

                return this.imageSources;
            }
            set
            {
                if (this.imageSources == null)
                {
                    this.imageSources = new ObservableCollection<BitmapImage>();
                }

                this.imageSources.Clear();
                value.ForEach(this.imageSources.Add);
            }
        }
    }
}
