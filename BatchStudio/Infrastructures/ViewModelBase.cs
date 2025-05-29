using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BatchStudio.Infrastructures
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(property, value) == false)
            {
                property = value;
                OnPropertyChanged(propertyName);
                return true;
            }
            return false;
        }
    }
}
