using System.ComponentModel;
using System.Runtime.CompilerServices;
using SimpleCalculator.Properties;

namespace SimpleCalculator.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if( field.Equals(value) )
                return;            
            field = value;
            OnPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}