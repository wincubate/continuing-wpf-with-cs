using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Wincubate.MvvmSolutions.Slide28.Model;

namespace Wincubate.MvvmSolutions.Slide28.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private int _counter;
        private RelayCommand _incrementCommand;

        public MainViewModel()
        {
            _incrementCommand = new RelayCommand(
                () => Increment());
        }

        public int Counter
        {
            get
            {
                return _counter;
            }
            set
            {
                if (value != _counter)
                {
                    _counter = value;

                    RaisePropertyChanged(() => Counter);
                }
            }
        }

        public ICommand IncrementCommand
        {
            get { return _incrementCommand; }
        }

        private void Increment()
        {
            Counter++;
        }
    }
}