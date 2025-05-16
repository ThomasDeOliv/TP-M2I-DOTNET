using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiSample.ViewModels.Base
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
