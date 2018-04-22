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
using System.Windows.Threading;

namespace Wincubate.ThreadsAndAsynchronyExamples.Slide04
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void OnJustDoItClick( object sender, RoutedEventArgs e )
        {
           DateTime dt = DateTime.Now;
           txtResult.Text = dt.ToLongTimeString();
        }

        private void OnNonUIClick( object sender, RoutedEventArgs e )
        {
           Thread t = new Thread( ThreadProc );
           t.Start( DateTime.Now );
        }

        private void ThreadProc( object state )
        {
           // Simulate computation
           Thread.SpinWait( 1000000000 );

           UpdateResult( state );

           //txtResult.Dispatcher.Invoke(
           //   DispatcherPriority.Normal,
           //   new Action<object>( UpdateResult ),
           //   state );
        }

        private void OnDispatcherClick( object sender, RoutedEventArgs e )
        {
           txtResult.Dispatcher.Invoke(
              DispatcherPriority.Normal,
              new Action<object>( UpdateResult ),
              DateTime.Now );
        }

        private void UpdateResult( object time )
        {
           //// Simulate computation
           //Thread.SpinWait( 1000000000 );

           DateTime dt = (DateTime) time;
           txtResult.Text = dt.ToLongTimeString();
        }
    }
}
