using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wincubate.IntroducingMvvmExamples.Slide09
{
   class SaveParticipantCommand : ICommand
   {
      private Action _executeAction;

      #region ICommand Members

      public bool CanExecute( object parameter )
      {
         return true;
      }

      public event EventHandler CanExecuteChanged;

      public void Execute( object parameter )
      {
         _executeAction.Invoke();
      }

      #endregion

      public SaveParticipantCommand( Action executeAction )
      {
         _executeAction = executeAction;
      }
   }
}
