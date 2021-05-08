using GalaSoft.MvvmLight.Ioc;
using System.Windows;
using System.Windows.Controls;
using Wincubate.MvvmPatternsExamples.Slide09.Services;

namespace Wincubate.MvvmPatternsExamples.Slide09.Views
{
    /// <summary>
    /// Interaction logic for ParticipantDetailView.xaml
    /// </summary>
    public partial class ParticipantDetailView : UserControl, IDialogService
    {
        public ParticipantDetailView()
        {
            InitializeComponent();
        }

        #region IDialogService Members 

        public bool Prompt(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }

        #endregion

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            SimpleIoc.Default.Register<IDialogService>(() => this);
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            SimpleIoc.Default.Unregister<IDialogService>();
        }
    }
}