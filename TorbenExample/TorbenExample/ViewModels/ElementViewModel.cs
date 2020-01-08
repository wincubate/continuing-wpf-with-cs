using System.Windows;
using System.Windows.Input;

namespace TorbenExample.ViewModels
{
    abstract class ElementViewModel : ViewModelBase
    {
        public string Name
        {
            get => _name;
            set
            {
                if( _name != value )
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _name;

        public string Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _value;

        public ICommand SaveValueCommand { get; }

        public ElementViewModel()
        {
            SaveValueCommand = new RelayCommand(
                o => MessageBox.Show(Value?.ToString() ?? "null"), // <-- Should *not* call view here in real life! :-)
                o => true
            ); ;
        }
    }
}
