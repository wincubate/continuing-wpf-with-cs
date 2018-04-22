using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Wincubate.MvvmSolutions.Slide25
{
   public class ParticipantsViewModel : ViewModelBase
   {
      private ParticipantService _participantService;
      
      #region Properties

      public ObservableCollection<ParticipantViewModel> Participants { get; private set; }

      /// <summary>
      /// The <see cref="SelectedParticipant" /> property's name.
      /// </summary>
      public const string SelectedParticipantPropertyName = "SelectedParticipant";

      private ParticipantViewModel _selectedParticipant;

      /// <summary>
      /// Sets and gets the SelectedParticipant property.
      /// Changes to that property's value raise the PropertyChanged event. 
      /// </summary>
      public ParticipantViewModel SelectedParticipant
      {
         get
         {
            return _selectedParticipant;
         }

         set
         {
            if ( _selectedParticipant == value )
            {
               return;
            }

            _selectedParticipant = value;
            RaisePropertyChanged( () => SelectedParticipant );

            //
            // TODO: Send ParticipantSelectionMessage message when selection changes!
            //
            Messenger.Default.Send(
               new ParticipantSelectionMessage { ParticipantId = value.Id }
            );
         }
      }

      #endregion

      public ParticipantsViewModel()
      {
         _participantService = new ParticipantService();

         var ps = new ObservableCollection<ParticipantViewModel>();

         foreach ( var p in _participantService.GetAll() )
         {
            ps.Add( new ParticipantViewModel
            {
               Id = p.Id,
               FirstName = p.FirstName,
               LastName = p.LastName,
               Company = p.Company
            }
            );
         }

         Participants = ps;
      }
   }
}
