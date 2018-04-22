using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wincubate.MvvmSolutions.Slide29
{
   class MainViewModel : INotifyPropertyChanged
   {
      public Participant ModelParticipant
      {
         get { return _modelParticipant; }
         set 
         { 
            _modelParticipant = value;
            OnPropertyChanged();
         }
      }
      private Participant _modelParticipant;

      public MainViewModel()
      {
         ModelParticipant = new Participant
         {
            FirstName = "Peter",
            LastName = "Graulund",
            Email = "peter@graulund.dk",
            RepeatEmail = "peter@graulund.dk"
         };
      }

      #region INotifyPropertyChanged Members

      public event PropertyChangedEventHandler PropertyChanged;

      private void OnPropertyChanged( [CallerMemberName] string propertyName = null )
      {
         PropertyChangedEventHandler del = PropertyChanged;
         if ( del != null )
         {
            del( this, new PropertyChangedEventArgs( propertyName ) );
         }
      }

      #endregion
   }
}
