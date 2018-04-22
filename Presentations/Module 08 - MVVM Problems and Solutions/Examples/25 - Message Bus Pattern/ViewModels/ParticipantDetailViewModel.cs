using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace Wincubate.MvvmSolutions.Slide25
{
   public class ParticipantDetailViewModel : ViewModelBase
   {
      private ParticipantService _participantService;

      #region Properties

      public int Id { get; set; }

      /// <summary>
      /// The <see cref="FirstName" /> property's name.
      /// </summary>
      public const string FirstNamePropertyName = "FirstName";

      private string _firstName = string.Empty;

      /// <summary>
      /// Sets and gets the FirstName property.
      /// Changes to that property's value raise the PropertyChanged event. 
      /// </summary>
      public string FirstName
      {
         get
         {
            return _firstName;
         }

         set
         {
            if ( _firstName == value )
            {
               return;
            }

            _firstName = value;
            RaisePropertyChanged( () => FirstName );
            RaisePropertyChanged( () => FullName );
         }
      }

      /// <summary>
      /// The <see cref="LastName" /> property's name.
      /// </summary>
      public const string LastNamePropertyName = "LastName";

      private string _lastName = string.Empty;

      /// <summary>
      /// Sets and gets the LastName property.
      /// Changes to that property's value raise the PropertyChanged event. 
      /// </summary>
      public string LastName
      {
         get
         {
            return _lastName;
         }

         set
         {
            if ( _lastName == value )
            {
               return;
            }

            _lastName = value;
            RaisePropertyChanged( () => LastName );
            RaisePropertyChanged( () => FullName );
         }
      }

      /// <summary>
      /// The <see cref="Company" /> property's name.
      /// </summary>
      public const string CompanyPropertyName = "Company";

      private string _company = string.Empty;

      /// <summary>
      /// Sets and gets the Company property.
      /// Changes to that property's value raise the PropertyChanged event. 
      /// </summary>
      public string Company
      {
         get
         {
            return _company;
         }

         set
         {
            if ( _company == value )
            {
               return;
            }

            _company = value;
            RaisePropertyChanged( () => Company );
         }
      }

      public string FullName
      {
         get
         {
            return string.Format( "{0} {1}",
               FirstName,
               LastName
            );
         }
      }

      #endregion

      #region Commands

      private RelayCommand _saveParticipantCommand;

      /// <summary>
      /// Gets the SaveParticipant.
      /// </summary>
      public RelayCommand SaveParticipantCommand
      {
         get
         {
            return _saveParticipantCommand
                ?? ( _saveParticipantCommand = new RelayCommand(
                                      () =>
                                      {
                                         _participantService.Update( new Participant
                                            {
                                               Id = this.Id,
                                               FirstName = this.FirstName,
                                               LastName = this.LastName,
                                               Company = this.Company
                                            }
                                          );

                                         //
                                         // TODO: Send ParticipantUpdatedMessage
                                         //
                                         Messenger.Default.Send( new ParticipantUpdatedMessage
                                         {
                                            ParticipantId = Id,
                                            FirstName = this.FirstName,
                                            LastName = this.LastName,
                                            Company = this.Company
                                         }
                                         );
                                      } ) );
         }
      }
      #endregion

      public ParticipantDetailViewModel()
      {
         _participantService = new ParticipantService();

         //
         // TODO: Register for ParticipantSelectionMessage messages
         //
         Messenger.Default.Register<ParticipantSelectionMessage>( this, message =>
            {
               Participant p = _participantService.GetById( message.ParticipantId );
               Id = p.Id;
               FirstName = p.FirstName;
               LastName = p.LastName;
               Company = p.Company;
            }
         );
      }
   }
}
