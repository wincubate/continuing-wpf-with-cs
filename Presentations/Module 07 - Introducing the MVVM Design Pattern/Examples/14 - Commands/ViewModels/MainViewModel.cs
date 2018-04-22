using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wincubate.IntroducingMvvmExamples.Slide09
{
    class MainViewModel : INotifyPropertyChanged
    {
        public ICommand SaveParticipantCommand
        {
            get { return _saveParticipantCommand; }
        }
        private ICommand _saveParticipantCommand;

        public Participant ModelParticipant
        {
            get { return _modelParticipant; }
            set
            {
                if (value != _modelParticipant)
                {
                    _modelParticipant = value;
                    OnPropertyChanged();
                }
            }
        }
        private Participant _modelParticipant;

        public MainViewModel()
        {
            ModelParticipant = new Participant
            {
                FirstName = "Peter",
                LastName = "Graulund"
            };

            _saveParticipantCommand = new SaveParticipantCommand(() =>
              {
                  ModelParticipant.LastUpdated = DateTime.Now;
              }
            );
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler del = PropertyChanged;
            if (del != null)
            {
                del(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
