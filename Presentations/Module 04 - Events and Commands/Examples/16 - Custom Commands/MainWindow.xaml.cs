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

namespace Wincubate.EventAndCommandsExamples.Slide16
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

        private void CommandBinding_CanExecute( object sender, CanExecuteRoutedEventArgs e )
        {
            e.CanExecute = checkBox.IsChecked ?? false;
        }

        private void CommandBinding_Executed( object sender, ExecutedRoutedEventArgs e )
        {
            System.Diagnostics.Process.Start( e.Parameter.ToString() );
        }
    }
}
