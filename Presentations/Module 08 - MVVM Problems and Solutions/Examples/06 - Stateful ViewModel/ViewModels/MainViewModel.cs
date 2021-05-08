using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Wincubate.MvvmPatternsExamples.Slide06
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Sets and gets the FirstName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FirstName
        {
            get =>_firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(NameTag));
                }
            }
        }
        private string _firstName = string.Empty;

        /// <summary>
        /// Sets and gets the LastName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LastName
        {
            get =>_lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(NameTag));
                }
            }
        }
        private string _lastName = string.Empty;

        /// <summary>
        /// Sets and gets the Company property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Company
        {
            get =>_company;
            set
            {
                if (_company != value)
                {
                    _company = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(NameTag));
                }
            }
        }
        private string _company = string.Empty;

        public string NameTag => $"{FirstName} {LastName}, {Company}";
    }
}
