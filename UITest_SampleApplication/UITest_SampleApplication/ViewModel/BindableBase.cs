﻿namespace UITest_SampleApplication.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            if (Equals(member, val)) return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

