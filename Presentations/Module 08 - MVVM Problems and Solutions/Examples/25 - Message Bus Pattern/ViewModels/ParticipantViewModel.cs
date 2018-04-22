using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Wincubate.MvvmSolutions.Slide25
{
   public class ParticipantViewModel : ViewModelBase
   {
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

      public ParticipantViewModel()
      {
         //
         // TODO: Register for ParticipantUpdatedMessage messages
         //
         Messenger.Default.Register<ParticipantUpdatedMessage>( this, message =>
         {
            if ( Id == message.ParticipantId )
            { 
               FirstName = message.FirstName ?? FirstName;
               LastName = message.LastName ?? LastName;
               Company = message.Company ?? Company;
            }
         } );
      }
   }
}
