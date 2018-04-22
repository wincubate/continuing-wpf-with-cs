using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Threading;
using System.Diagnostics;

namespace Wincubate.EventAndCommandsExamples.Slide11
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
      private void Application_Startup( object sender, StartupEventArgs e )
      {
         Debug.WriteLine( "Application_Startup" );

         //Thread.Sleep( 5000 );

         #region Handle command-line arguments
         //bool startMinimized = false;
         //for( int i = 0 ; i != e.Args.Length ; ++i )
         //{
         //   if( e.Args[ i ] == "/StartMinimized" )
         //   {
         //      startMinimized = true;
         //   }
         //}

         //// Create the main application window, starting minimized 
         //// if specified.
         //MainWindow mainWindow = new MainWindow();
         //if( true == startMinimized )
         //{
         //   mainWindow.WindowState = WindowState.Minimized;
         //}

         //mainWindow.Show();
         #endregion
      }

      private void Application_Activated( object sender, EventArgs e )
      {
         Debug.WriteLine( "Application_Activated" );
      }

      private void Application_Deactivated( object sender, EventArgs e )
      {
         Debug.WriteLine( "Application_Deactivated" );
      }

      private void Application_SessionEnding( object sender, SessionEndingCancelEventArgs e )
      {
         Debug.WriteLine( "Application_SessionEnding" );

         //if( e.ReasonSessionEnding == ReasonSessionEnding.Logoff )
         //{
         //   MessageBox.Show( "No way you're going to log off on me...! ;-)" );

         //   e.Cancel = true;
         //}
      }

      private void Application_Exit( object sender, ExitEventArgs e )
      {
         Debug.WriteLine( "Application_Exit" );

         //Wincubate.EventAndCommandsExamples.Slide11.Properties.Settings.Default.Save();
      }
   }
}
