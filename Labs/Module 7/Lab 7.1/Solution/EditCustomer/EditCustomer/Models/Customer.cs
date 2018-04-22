using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EditCustomer
{
    public class Customer : INotifyPropertyChanged, IDataErrorInfo
    {
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (value != _fullName)
                {
                    _fullName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _fullName;

        public string CouponCode
        {
            get { return _couponCode; }
            set
            {
                if (value != _couponCode)
                {
                    _couponCode = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _couponCode;

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
            get
            {
                return null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case "FullName":
                        {
                            if (string.IsNullOrWhiteSpace(FullName) || FullName.Trim().Length < 3)
                            {
                                error = "Full name must consist of at least three characters";
                            }
                            break;
                        }
                    case "CouponCode":
                        {
                            if (string.IsNullOrWhiteSpace(CouponCode) || CouponCode.Length != 6)
                            {
                                error = "Coupon code must consist of exactly six characters";
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
