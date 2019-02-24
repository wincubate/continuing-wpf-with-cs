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
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace Wincubate.Module12.Slide14
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private Process process;
      private const string ExecutablePath = @"..\..\..\04 - Test Application\bin\Debug\Wincubate.TestingDebuggingExamples.Slide04TestApp.exe";
      private const string ApplicationName = "Test Application";

      /// <summary>
      /// Starts a process for the given executable.
      /// </summary>
      /// <param name="path">The path to the executable to run.</param>
      /// <returns>The new process</returns>
      private Process StartProcess( string path )
      {
         process = new Process();
         process.StartInfo = new ProcessStartInfo( path );
         process.Start();

         return process;
      }

      public MainWindow()
      {
         InitializeComponent();
      }

      private void Button_Click( object sender, RoutedEventArgs e )
      {
         StartProcess( ExecutablePath );

         Thread.Sleep( 5000 );

         AutomationElement desktop = AutomationElement.RootElement;
         AutomationElement button = desktop.FindFirst( TreeScope.Descendants,
            new PropertyCondition( AutomationElement.AutomationIdProperty, "doStuff" ) );

         InvokePattern pattern =
            button.GetCurrentPattern( InvokePattern.Pattern ) as InvokePattern;
         pattern.Invoke();
      }
   }
}
