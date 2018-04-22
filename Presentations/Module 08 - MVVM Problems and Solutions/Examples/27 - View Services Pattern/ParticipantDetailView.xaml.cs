using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using Wincubate.MvvmSolutions.Slide27.Services;
using Wincubate.MvvmSolutions.Slide27.ViewModel;

namespace Wincubate.MvvmSolutions.Slide27
{
   /// <summary>
   /// Description for ParticipantDetailView.
   /// </summary>
   public partial class ParticipantDetailView : UserControl, IDialogService
   {
      /// <summary>
      /// Initializes a new instance of the ParticipantDetailView class.
      /// </summary>
      public ParticipantDetailView()
      {
         InitializeComponent();
      }

      #region IDialogService Members

      public bool Prompt( string message, string caption )
      {
         return MessageBox.Show( message, caption, MessageBoxButton.YesNo ) == MessageBoxResult.Yes;
      }

      #endregion

      private void OnLoaded( object sender, RoutedEventArgs e )
      {
         SimpleIoc.Default.Register<IDialogService>( () => this );
      }

      private void OnUnloaded( object sender, RoutedEventArgs e )
      {
         SimpleIoc.Default.Unregister<IDialogService>();
      }
   }
}