using GalaSoft.MvvmLight.Messaging;
using Wincubate.MvvmPatternsExamples.Slide08.ViewModels.Messages;

namespace Wincubate.MvvmPatternsExamples.Slide08.ViewModels
{
    public class ParticipantViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        #region Properties

        public int Id { get; set; }

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
                if (_firstName == value)
                {
                    return;
                }

                _firstName = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(FullName));
            }
        }

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
                if (_lastName == value)
                {
                    return;
                }

                _lastName = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(FullName));
            }
        }

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
                if (_company == value)
                {
                    return;
                }

                _company = value;
                RaisePropertyChanged();
            }
        }

        public string FullName => $"{FirstName} {LastName}";

        #endregion

        private readonly IMessenger _messenger;

        public ParticipantViewModel(IMessenger messenger)
        {
            _messenger = messenger;

            _messenger.Register<ParticipantUpdatedMessage>(this, OnParticipantUpdated);
        }

        private void OnParticipantUpdated(ParticipantUpdatedMessage message)
        {
            if (Id == message.ParticipantId)
            {
                FirstName = message.FirstName ?? FirstName;
                LastName = message.LastName ?? LastName;
                Company = message.Company ?? Company;
            }
        }
    }
}