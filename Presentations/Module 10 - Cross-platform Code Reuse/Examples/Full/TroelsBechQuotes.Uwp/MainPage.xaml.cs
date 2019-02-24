using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TroelsBechQuotes.Pcl.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TroelsBechQuotes.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, IDialogService
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo( NavigationEventArgs e )
        {
            SimpleIoc.Default.Register<IDialogService>(() => this);

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom( NavigationEventArgs e )
        {
            SimpleIoc.Default.Unregister<IDialogService>();

            base.OnNavigatedFrom(e);
        }

        #region IDialogService Members

        async public Task<DialogResult> ShowAsync( string message, string title )
        {
            DialogResult result = await this.ShowAsync(message, title, DialogButtons.OK);
            return result;
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

            MessageDialog dialog = new MessageDialog(message, title);
            DialogResult result = DialogResult.None;
            switch (buttons)
            {
                case DialogButtons.OK:
                    {
                        dialog.Commands.Add(
                           new UICommand("OK", new UICommandInvokedHandler(
                              o => result = DialogResult.OK)));
                        break;
                    }
                case DialogButtons.OKCancel:
                    {
                        dialog.Commands.Add(new UICommand("OK",
                          new UICommandInvokedHandler(o => result = DialogResult.OK)));
                        dialog.Commands.Add(new UICommand("Cancel",
                          new UICommandInvokedHandler(o => result = DialogResult.Cancel)));
                        break;
                    }
                case DialogButtons.YesNo:
                    {
                        dialog.Commands.Add(new UICommand("Yes",
                          new UICommandInvokedHandler(o => result = DialogResult.Yes)));
                        dialog.Commands.Add(new UICommand("No",
                          new UICommandInvokedHandler(o => result = DialogResult.No)));
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException(
                          string.Format("DialogButtons.{0} is not supported.",
                          buttons.ToString()));
                    }
            }
            dialog.DefaultCommandIndex = 1;
            // Determine whether the calling thread is the
            // thread associated with the Dispatcher.
            if (Window.Current.Dispatcher.HasThreadAccess)
            {
                await dialog.ShowAsync();
            }
            else
            {
                // Execute asynchronously on the thread the Dispatcher is associated with.
                await Window.Current.Dispatcher.RunAsync(
                  CoreDispatcherPriority.Normal, async () =>
                  {
                      await dialog.ShowAsync();
                  });
            }
            return result;
        }

        #endregion
    }
}
