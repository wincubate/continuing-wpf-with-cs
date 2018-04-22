using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Wincubate.EventAndCommandsExamples.Slide11UE
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

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            int n = 87;
            MessageBox.Show( ( 1 / ( n - 87 ) ).ToString() );
        }

        private void Button_Click2( object sender, RoutedEventArgs e )
        {
           ThreadPool.QueueUserWorkItem(
               i =>
               {
                  int n = 87;
                  Console.WriteLine( 1 / ( 87 - n ) );
               }
           );
        }
    }
}
