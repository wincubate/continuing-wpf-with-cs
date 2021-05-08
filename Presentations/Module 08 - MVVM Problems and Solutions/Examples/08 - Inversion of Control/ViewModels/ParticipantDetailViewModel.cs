using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using Wincubate.MvvmPatternsExamples.Data;
using Wincubate.MvvmPatternsExamples.Slide08.Models;
using Wincubate.MvvmPatternsExamples.Slide08.ViewModels.Messages;

namespace Wincubate.MvvmPatternsExamples.Slide08.ViewModels
{
    public class ParticipantDetailViewModel : GalaSoft.MvvmLight.ViewModelBase
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

        #region Commands

        public ICommand SaveParticipantCommand => _saveParticipantCommand;
        private readonly RelayCommand _saveParticipantCommand;

        #endregion

        private IMessenger _messenger;
        private IParticipantService _participantService;

        public ParticipantDetailViewModel(
            IMessenger messenger,
            IParticipantService participantService
        )
        {
            _messenger = messenger;
            _participantService = participantService;

            _saveParticipantCommand = new RelayCommand(() => SaveParticipant());

            _messenger.Register<ParticipantSelectionMessage>(this, OnParticipantSelected);
        }

        private void OnParticipantSelected(ParticipantSelectionMessage message)
        {
            Participant p = _participantService.GetById(message.ParticipantId);

            Id = p.Id;
            FirstName = p.FirstName;
            LastName = p.LastName;
            Company = p.Company;
        }

        private void SaveParticipant()
        {
            _participantService.Update(new Participant
            (
                Id,
                FirstName,
                LastName,
                Company
            )
            );

            _messenger.Send(new ParticipantUpdatedMessage
            (
                Id,
                FirstName,
                LastName,
                Company
            )
            );
        }
    }
}