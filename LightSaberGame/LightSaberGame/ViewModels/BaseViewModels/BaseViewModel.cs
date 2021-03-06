﻿namespace LightSaberGame.ViewModels.BaseViewModels
{
    using System.ComponentModel;
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
            {
                return;
            }
            var propertyEventArgs = new PropertyChangedEventArgs(propertyName);
            this.PropertyChanged.Invoke(this, propertyEventArgs);
        }
    }
}
