using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SimpleCalculator
{
	class MainViewModel : ObservableObject
	{
		public Display ModelDisplay { get; }

		public ICommand DigitCommand { get; }
		public ICommand ClearCommand { get; }
		public ICommand ResultCommand { get; }

		private Action<string> _resultAction;

		public MainViewModel( Action<string> resultAction )
		{
			_resultAction = resultAction;
			ModelDisplay = new Display();

			DigitCommand = new DelegateCommand(
				 digit => ModelDisplay.Update( digit.ToString() )
			);
			ClearCommand = new DelegateCommand(
				 o => ModelDisplay.Clear(),
				 o => !ModelDisplay.IsEmpty
			);
			ResultCommand = new DelegateCommand(
				 o =>
				 {
					 _resultAction( ModelDisplay.Contents );
					 ModelDisplay.Clear();
				 }
			);
		}
	}
}
