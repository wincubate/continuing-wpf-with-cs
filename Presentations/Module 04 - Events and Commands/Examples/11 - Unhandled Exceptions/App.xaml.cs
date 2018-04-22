using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace Wincubate.EventAndCommandsExamples.Slide11UE
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
      public App()
      {
         AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler( OnUnhandledException );
      }

      private void OnDispatcherUnhandledException( object sender, DispatcherUnhandledExceptionEventArgs e )
      {
         MessageBox.Show(
            e.Exception.ToString(),
            "Unhandled exceptions for WPF" );

         e.Handled = true;
      }

      void OnUnhandledException( object sender, UnhandledExceptionEventArgs e )
      {
         MessageBox.Show(
            e.ExceptionObject.ToString(),
            "Unhandled exceptions for non-WPF" );
      }
   }
}
