using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TroelsBechQuotes.Pcl.Services;

namespace TroelsBechQuotes.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDialogService
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            SimpleIoc.Default.Register<IDialogService>( () => this);
        }

        private void Window_Unloaded( object sender, RoutedEventArgs e )
        {
            SimpleIoc.Default.Unregister<IDialogService>(this);
        }

        #region IDialogService Implementation

        public Task<DialogResult> ShowAsync( string message, string title )
        {
            return ShowAsync(message, title, DialogButtons.OK);
        }

        async public Task<DialogResult> ShowAsync( string message, string title, DialogButtons buttons )
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException(
                  "The specified message cannot be null or empty.", "message");
            }
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException(
                  "The specified title cannot be null or empty.", "title");
            }
            MessageBoxResult result = MessageBoxResult.None;

            // Determine whether the calling thread is the thread
            // associated with the Dispatcher.
            if (this.Dispatcher.CheckAccess())
            {
                result = MessageBox.Show(message, title, (MessageBoxButton)buttons);
            }
            else
            {
                // Execute asynchronously on the thread the Dispatcher is associated with. 
                await this.Dispatcher.InvokeAsync(() =>
                {
                    result = MessageBox.Show(message, title,
                    (MessageBoxButton)buttons);
                });
            }

            return (DialogResult)result;
        }

        #endregion
    }
}
