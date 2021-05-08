using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wincubate.IntroducingMvvmExamples.Data
{
    public class Participant : INotifyPropertyChanged
    {
        #region Properties

        static Uri ImageNotAvailableUri
        {
            get
            {
                return new Uri("pack://application:,,,/Wincubate.IntroducingMvvmExamples.Data;component/nophoto.gif");
            }
        }

        public string FullName
        {
            get
            {
                return (FirstName ?? "") + " " + (LastName ?? "");
            }
        }

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

        public Uri ImageUri
        {
            get
            {
                return _imageUri;
            }
            set
            {
                if (value != _imageUri)
                {
                    _imageUri = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private Uri _imageUri;

        public IList<Module> FavoriteModules
        {
            get
            {
                return _favoriteModules;
            }
            set
            {
                if (value.SequenceEqual(_favoriteModules) == false)
                {
                    _favoriteModules = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private IList<Module> _favoriteModules;

        #endregion

        #region Constructors

        public Participant()
           : this(
               "Gulmann Henriksen",
               "Jesper",
               "Wincubate",
               new Uri("pack://application:,,,/Wincubate.IntroducingMvvmExamples.Data;component/JGH.jpg"))
        {
        }

        public Participant(string lastName, string firstName, string company)
           : this(
               lastName,
               firstName,
               company,
               ImageNotAvailableUri)
        {
        }

        public Participant(string lastName, string firstName, string company, Uri imageUri)
        {
            LastName = lastName;
            FirstName = firstName;
            Company = company;
            ImageUri = imageUri;

            #region Set random favorite modules

            int j = 1;
            _favoriteModules = new List<Module>();
            Random random = new Random((lastName + FirstName).Length);
            for (int i = 0; i < 3; i++)
            {
                j += 1 + random.Next(3);

                _favoriteModules.Add(new Module
                {
                    Title = "Module " + j
                });
            }

            #endregion
        }

        #endregion

        #region Custom Filter

        public static bool CustomFilter(object o)
        {
            Participant p = o as Participant;

            return p.Company.Length > 15;
        }

        #endregion

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
