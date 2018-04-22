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
using System.Windows.Threading;
using System.Threading;
using System.ComponentModel;

namespace Wincubate.ThreadsAndAsynchronyExamples.Slide06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _dispatcherTimer = null;

        public MainWindow()
        {
            InitializeComponent();

            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler( OnDispatcherTimerTick );
            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds( 1000 );
        }

        private static string GenerateTickString()
        {
            return string.Format( "{0}", ( DateTime.Now.ToLongTimeString() ) );
        }

        private void btnStart_Click( object sender, RoutedEventArgs e )
        {
           _dispatcherTimer.Start();
        }

        private void btnStop_Click( object sender, RoutedEventArgs e )
        {
           _dispatcherTimer.Stop();
        }

        void OnDispatcherTimerTick( object sender, EventArgs e )
        {
            lst.Items.Add( GenerateTickString() );
        }
    }
}
