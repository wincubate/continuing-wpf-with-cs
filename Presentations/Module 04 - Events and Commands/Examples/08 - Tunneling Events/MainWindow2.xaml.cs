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
using System.Windows.Shapes;

namespace Wincubate.EventAndCommandsExamples.Slide08
{
    /// <summary>
    /// Interaction logic for MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
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

        private void OnButtonClicked( object sender, RoutedEventArgs e )
        {
            this.lstEvents.Items.Add( "Click @ " + sender.ToString() );
        }

        private void OnClear( object sender, RoutedEventArgs e )
        {
            this.lstEvents.Items.Clear();
        }
    }
}
