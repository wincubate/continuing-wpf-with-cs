using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    class ViewModelLocator
    {
        private static MainViewModel _main;

        public MainViewModel Main
        {
            get
            {
                return _main;
            }
        }

        public ViewModelLocator()
        {
            // Poor-man's Dependecy Injection ;-)
            _main = new MainViewModel(
                msg => System.Windows.MessageBox.Show(msg, "Result")    
            );
        }
    }
}
