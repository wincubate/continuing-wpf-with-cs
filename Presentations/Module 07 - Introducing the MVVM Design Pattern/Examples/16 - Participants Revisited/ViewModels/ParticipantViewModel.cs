using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wincubate.IntroducingMvvmExamples.Data;

namespace Wincubate.IntroducingMvvmExamples.Slide16
{
   public class ParticipantViewModel : ViewModelBase
   {
      private Participant _participant;

      #region Properties

      public string FirstName
      {
         get
         {
            return _participant.FirstName;
         }
         set
         {
            if ( _participant.FirstName != value )
            {
               _participant.FirstName = value;

               OnPropertyChanged();
               OnPropertyChanged( "FullName" );
            }
         }
      }

      public string LastName
      {
         get
         {
            return _participant.LastName;
         }
         set
         {
            if ( _participant.LastName != value )
            {
               _participant.LastName = value;

               OnPropertyChanged();
               OnPropertyChanged( "FullName" );
            }
         }
      }

      public string FullName
      {
         get
         {
            return _participant.FullName;
         }
      }

      public string Company
      {
         get
         {
            return _participant.Company;
         }
         set
         {
            if ( _participant.Company != value )
            {
               _participant.Company = value;

               OnPropertyChanged();
            }
         }
      }

      public Uri ImageUri
      {
         get
         {
            return _participant.ImageUri;
         }
         set
         {
            if ( _participant.ImageUri != value )
            {
               _participant.ImageUri = value;

               OnPropertyChanged();
            }
         }
      }

      #endregion

      public ParticipantViewModel( Participant participant )
      {
         _participant = participant;
      }
   }
}
