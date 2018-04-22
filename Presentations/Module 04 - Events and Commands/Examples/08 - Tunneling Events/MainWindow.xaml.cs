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

namespace Wincubate.EventAndCommandsExamples.Slide08
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

        private void OnPreviewMouseDown( object sender, MouseButtonEventArgs e )
        {
            this.lstEvents.Items.Add( "PreviewMouseDown @ " + sender.ToString() );

            // Will stop also the bubbling event KeyDown
            //e.Handled = true;
        }

        private void OnMouseDown( object sender, MouseButtonEventArgs e )
        {
            this.lstEvents.Items.Add( "MouseDown @ " + sender.ToString() );
        }

        private void OnClear( object sender, RoutedEventArgs e )
        {
            this.lstEvents.Items.Clear();
        }
    }
}
