using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Wincubate.DataBindingPropertiesExamples.Data
{
    public class Participant // : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Properties

        static Uri ImageNotAvailableUri
        {
            get
            {
                return new Uri( "pack://application:,,,/Wincubate.DataBindingPropertiesExamples.Data;component/nophoto.gif" );
            }
        }
        
        public string FullName
        {
            get
            {
                return ( FirstName ?? "" ) + " " + ( LastName ?? "" );
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
                _lastName = value;
                //NotifyPropertyChanged("LastName");
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
                _firstName = value;
                //NotifyPropertyChanged("FirstName");
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
                _company = value;
                //NotifyPropertyChanged("Company");
            }
        }
        private string _company;

        public Uri ImageUri { get; set; }

        public IList<Module> FavoriteModules { get; set; }

        #endregion

        #region Constructors

        public Participant()
            : this(
                "Gulmann Henriksen",
                "Jesper",
                "Wincubate",
                new Uri( "pack://application:,,,/Wincubate.DataBindingPropertiesExamples.Data;component/JGH.jpg" ) )
        {
        }

        public Participant( string lastName, string firstName, string company )
            : this(
                lastName,
                firstName,
                company,
                ImageNotAvailableUri )
        {
        }

        public Participant( string lastName, string firstName, string company, Uri imageUri )
        {
            LastName = lastName;
            FirstName = firstName;
            Company = company;
            ImageUri = imageUri;

            #region Set random favorite modules

            int j = 1;
            FavoriteModules = new List<Module>();
            Random random = new Random( ( lastName + FirstName ).Length );
            for( int i = 0; i < 3; i++ )
            {
                j += 1 + random.Next( 3 );

                FavoriteModules.Add( new Module { Title = "Module " + j } );
            }

            #endregion
        }

        #endregion

        #region Custom Filter

        public static bool CustomFilter( object o )
        {
            Participant p = o as Participant;

            return p.Company.Length > 15;
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged( string propertyName )
        {
            PropertyChangedEventHandler del = PropertyChanged;
            if( del != null )
            {
                del( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }

        #endregion

        #region IDataErrorInfo

        public string Error
        {
           get { return null; }
        }

        public string this[ string columnName ]
        {
           get
           {
              string result = null;

              if ( columnName == "FirstName" )
              {
                 if ( string.IsNullOrEmpty( FirstName ) )
                 {
                    result = "First name must be non-empty!";
                 }
              }
              else if ( columnName == "LastName" )
              {
                 if ( string.IsNullOrEmpty( LastName ) )
                 {
                    result = "Last name must be non-empty!";
                 }
              }

              return result;
           }
        }

        #endregion
    }
}
