using System.ComponentModel;

namespace UpdatingCastMembers
{
    class CastMember : INotifyPropertyChanged
    {
        public string Character
        {
            get => _character;
            set
            {
                if (_character != value)
                {
                    _character = value;
                    NotifyPropertyChanged(nameof(Character));
                }
            }
        }
        private string _character;

        public string ActorName
        {
            get => _actorName;
            set
            {
                if (_actorName != value)
                {
                    _actorName = value;
                    NotifyPropertyChanged(nameof(ActorName));
                }
            }
        }
        private string _actorName;

        public string Image
        {
            get => _image;
            set
            {
                if (_image != value)
                {
                    _image = value;
                    NotifyPropertyChanged(nameof(Image));
                }
            }
        }
        private string _image;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
