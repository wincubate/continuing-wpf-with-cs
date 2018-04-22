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

namespace Wincubate.DataBindingPropertiesExamples.Slide16
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new Wincubate.DataBindingPropertiesExamples.Data.Participant();
        }

        private void StackPanel_Error( object sender, ValidationErrorEventArgs e )
        {
            if( e.Action == ValidationErrorEventAction.Added )
            {
                MessageBox.Show( e.Error.ErrorContent.ToString() );
            }
        }
    }
}
