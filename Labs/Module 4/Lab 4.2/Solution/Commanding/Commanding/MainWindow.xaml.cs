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

namespace Commanding
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      private void DoSave()
      {
         MessageBox.Show( "Saving..." );

         DoNew();
      }

      private void DoNew()
      {
         txtFirstName.Clear();
         txtLastName.Clear();
      }

      private void NewExecuted( object sender, ExecutedRoutedEventArgs e )
      {
         DoNew();
      }

      private void CommandBinding_CanExecute( object sender, CanExecuteRoutedEventArgs e )
      {
         e.CanExecute = ( txtFirstName.Text.Trim().Length > 0 && txtLastName.Text.Trim().Length > 0 );
      }

      private void SaveExecuted( object sender, ExecutedRoutedEventArgs e )
      {
         DoSave();
      }
   }
}
