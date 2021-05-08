using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Wincubate.MvvmPatternsExamples.Slide07.Models;
using Wincubate.MvvmPatternsExamples.Slide07.ViewModels.Messages;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Wincubate.MvvmPatternsExamples.Slide07.ViewModels
{
    public class AllParticipantsViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;
        private readonly IParticipantService _participantRepository;

        #region Properties

        public ObservableCollection<ParticipantViewModel> Participants { get; private set; }

        private ParticipantViewModel _selectedParticipant;

        /// <summary>
        /// Sets and gets the SelectedParticipant property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ParticipantViewModel SelectedParticipant
        {
            get =>_selectedParticipant;
            set
            {
                if (_selectedParticipant != value)
                {
                    _selectedParticipant = value;
                    RaisePropertyChanged();

                    OnSelectParticipant(_selectedParticipant);
                }
            }
        }

        #endregion

        #region Commands

        public ICommand SelectParticipantCommand => _selectParticipantCommand;
        private readonly RelayCommand<ParticipantViewModel> _selectParticipantCommand;

        #endregion

        public AllParticipantsViewModel(
            IMessenger messenger,
            IParticipantService participantRepository
        )
        {
            _messenger = messenger;
            _participantRepository = participantRepository;

            var ps = new ObservableCollection<ParticipantViewModel>();

            foreach (var p in _participantRepository.GetAll())
            {
                ps.Add(new ParticipantViewModel(_messenger)
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Company = p.Company
                }
                );
            }

            Participants = ps;

            _selectParticipantCommand = new RelayCommand<ParticipantViewModel>(OnSelectParticipant);
        }

        private void OnSelectParticipant(ParticipantViewModel selectedParticipant) =>
            _messenger.Send(
               new ParticipantSelectionMessage ( selectedParticipant.Id )
            );
    }
}