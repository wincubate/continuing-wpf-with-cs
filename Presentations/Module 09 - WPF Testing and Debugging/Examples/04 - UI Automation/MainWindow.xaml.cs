using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Threading;

namespace Wincubate.Module12.Slide14
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      int _counter;
      DispatcherTimer _timer;

      public MainWindow()
      {
         InitializeComponent();

         //_counter = 0;
         //_timer = new DispatcherTimer();
         //_timer.Interval = TimeSpan.FromMilliseconds( 1000 );
         //_timer.Tick += OnTimerTick;
         //_timer.Start();
      }

      void OnTimerTick( object sender, EventArgs e )
      {
         UIAutomationButtonClick();
      }

      private void btn_Click( object sender, RoutedEventArgs e )
      {
         lbl.Content = _counter++.ToString();
      }

      private void UIAutomationButtonClick()
      {
         ButtonAutomationPeer btnAutomationPeer = new ButtonAutomationPeer( btn );
         IInvokeProvider provider = btnAutomationPeer.GetPattern( PatternInterface.Invoke ) as IInvokeProvider;
         provider.Invoke();
      }
   }
}
