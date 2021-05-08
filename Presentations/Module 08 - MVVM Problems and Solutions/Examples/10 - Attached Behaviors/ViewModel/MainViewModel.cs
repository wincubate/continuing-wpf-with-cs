using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Wincubate.MvvmPatternsExamples.Slide10.ViewModel
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

        public MainViewModel()
        {
            IncrementCommand = new RelayCommand(
                () => Increment()
            );
        }

        public int Counter
        {
            get => _counter;
            set
            {
                if (value != _counter)
                {
                    _counter = value;

                    RaisePropertyChanged();
                }
            }
        }

        public ICommand IncrementCommand { get; }

        private void Increment()
        {
            Counter++;
        }
    }
}