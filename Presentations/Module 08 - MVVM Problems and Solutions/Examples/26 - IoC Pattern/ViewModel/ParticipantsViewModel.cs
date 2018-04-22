using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Wincubate.MvvmSolutions.Slide26.Messages;
using Wincubate.MvvmSolutions.Slide26.Model;

namespace Wincubate.MvvmSolutions.Slide26.ViewModel
{
   /// <summary>
   /// This class contains properties that a View can data bind to.
   /// <para>
   /// See http://www.galasoft.ch/mvvm
   /// </para>
   /// </summary>
   public class ParticipantsViewModel : ViewModelBase
   {
      private IParticipantService _participantService;

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

      /// <summary>
      /// Initializes a new instance of the ParticipantsViewModel class.
      /// </summary>
      public ParticipantsViewModel( IParticipantService participantService )
      {
         _participantService = participantService;

         var ops = new ObservableCollection<ParticipantViewModel>();

         _participantService.GetAll( ( ps, error ) =>
            {
               if ( error != null )
               {
                  // Report error here
                  return;
               }

               foreach ( var p in ps )
               {
                  ops.Add( new ParticipantViewModel
                  {
                     Id = p.Id,
                     FirstName = p.FirstName,
                     LastName = p.LastName,
                     Company = p.Company
                  }
                  );
               }

               Participants = ops;
            } );
      }
   }
}