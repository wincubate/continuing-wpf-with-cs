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

namespace Wincubate.FundamentalsExamples.Slide17
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

        private void btnChangeBrushColor_Click( object sender, RoutedEventArgs e )
        {
            // Lookup
            SolidColorBrush b = this.Resources[ "brush" ] as SolidColorBrush;
            b.Color = Colors.Chocolate;
        }

        private void btnChangeBrush_Click( object sender, RoutedEventArgs e )
        {
            this.Resources[ "brush" ] = new SolidColorBrush( Colors.CadetBlue );
        }

        private void btnLookupOtherBrush_Click( object sender, RoutedEventArgs e )
        {

            // "DynamicResource"
            btnA.SetResourceReference( Button.BackgroundProperty, "otherBrush" );

            // "StaticResource"
            Brush b = btnB.FindResource( "otherBrush" ) as Brush;
            btnB.Background = b;
        }

        private void btnChangeOtherBrush_Click( object sender, RoutedEventArgs e )
        {
            // Add
            this.Resources[ "otherBrush" ] = new SolidColorBrush( Colors.WhiteSmoke );
        }
    }
}
