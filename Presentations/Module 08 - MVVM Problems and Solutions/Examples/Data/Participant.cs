using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wincubate.MvvmPatternsExamples.Data
{
    public class Participant : INotifyPropertyChanged
    {
        public int Id { get; private set; }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("FullName");
                }
            }
        }
        private string _lastName;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("FullName");
                }
            }
        }
        private string _firstName;

        public string Company
        {
            get
            {
                return _company;
            }
            set
            {
                if (value != _company)
                {
                    _company = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _company;

        public Participant(int id, string lastName, string firstName, string company)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Company = company;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
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
