using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EditCustomer
{
   class SaveCustomerCommand : ICommand
   {
      private Action<object> _executeAction;
      private Predicate<object> _canExecute;

      public SaveCustomerCommand( Action<object> executeAction, Predicate<object> canExecutePredicate )
      {
         _executeAction = executeAction;
         _canExecute = canExecutePredicate;
      }

      #region ICommand Members

      public bool CanExecute( object parameter )
      {
         return _canExecute( parameter );
      }

      public event EventHandler CanExecuteChanged
      {
         add
         { 
            CommandManager.RequerySuggested += value;
         }
         remove 
         { 
            CommandManager.RequerySuggested -= value; 
         }
      }

      public void Execute( object parameter )
      {
         _executeAction( parameter );
      }

      #endregion
   }
}
