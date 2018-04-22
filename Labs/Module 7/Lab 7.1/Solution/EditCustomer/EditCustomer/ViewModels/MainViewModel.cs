using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EditCustomer
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Customer ModelCustomer
        {
            get { return _modelCustomer; }
            set
            {
                if (value != _modelCustomer)
                {
                    _modelCustomer = value;
                    OnPropertyChanged();
                }
            }
        }
        private Customer _modelCustomer;

        public ICommand SaveCustomerCommand
        {
            get { return _saveCustomerCommand; }
        }
        private ICommand _saveCustomerCommand;

        public MainViewModel()
        {
            ModelCustomer = new Customer
            {
                FullName = "Jesper Gulmann Henriksen",
                CouponCode = "SHOPXX"
            };

            _saveCustomerCommand = new SaveCustomerCommand(
               o =>
               {
                   ModelCustomer.LastUpdated = DateTime.Now;
               },
               o => ModelCustomer.HasOverallError() == false
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
