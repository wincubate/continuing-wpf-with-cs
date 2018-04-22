using System.Windows;
using Wincubate.MvvmSolutions.Slide27.ViewModel;

namespace Wincubate.MvvmSolutions.Slide27
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      /// <summary>
      /// Initializes a new instance of the MainWindow class.
      /// </summary>
      public MainWindow()
      {
         InitializeComponent();
         Closing += ( s, e ) => ViewModelLocator.Cleanup();
      }
   }
}