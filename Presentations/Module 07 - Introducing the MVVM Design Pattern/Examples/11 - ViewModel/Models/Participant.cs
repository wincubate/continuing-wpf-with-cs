using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Wincubate.IntroducingMvvmExamples.Slide09
{
    class Participant : INotifyPropertyChanged, IDataErrorInfo
    {
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _firstName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _lastName;

        public DateTime LastUpdated
        {
            get { return _lastUpdated; }
            set
            {
                if (value != _lastUpdated)
                {
                    _lastUpdated = value;
                    OnPropertyChanged();
                }
            }
        }
        private DateTime _lastUpdated;

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

        #region IDataErrorInfo Members

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                switch (columnName)
                {
                    case "FirstName":
                        {
                            if (string.IsNullOrEmpty(FirstName))
                            {
                                error = "First name is required";
                            }
                            break;
                        }
                    case "LastName":
                        {
                            if (string.IsNullOrEmpty(LastName))
                            {
                                error = "Last name is required";
                            }
                            break;
                        }
                }

                return error;
            }
        }

        #endregion
    }
}
