using System.Windows;
using Wincubate.MvvmPatternsExamples.Slide10.ViewModel;

namespace Wincubate.MvvmPatternsExamples.Slide10
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