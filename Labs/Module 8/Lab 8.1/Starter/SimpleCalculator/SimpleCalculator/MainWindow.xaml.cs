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

namespace SimpleCalculator
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

      private void OnDigitClicked( object sender, RoutedEventArgs e )
      {
         Button button = e.Source as Button;
         if ( button != null )
         {
            UpdateDisplay( button.Content.ToString() );
         }
      }

      private void UpdateDisplay( string digit )
      {
         if ( txtDisplay.Text == "0" )
         {
            txtDisplay.Text = digit;
         }
         else
         {
            txtDisplay.Text += digit;
         }
      }

      private void OnClearClicked( object sender, RoutedEventArgs e )
      {
         ClearDisplay();
         e.Handled = true;
      }

      private void OnShowResultClicked( object sender, RoutedEventArgs e )
      {
         MessageBox.Show( txtDisplay.Text, "Result" );
         ClearDisplay();
         e.Handled = true;
      }

      private void ClearDisplay()
      {
         txtDisplay.Text = "0";
      }
   }
}
