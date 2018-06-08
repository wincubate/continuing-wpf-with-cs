using System;
using System.Threading.Tasks;
using System.Windows;

namespace TaskTest
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

      // TODO
      Task<int> ComputeLengthSumAsync()
      {
         Task<string> t1 = CreateFetchTask( "http://www.jp.dk/" );
         Task<string> t2 = CreateFetchTask( "http://www.bt.dk/" );
         Task<string> t3 = CreateFetchTask( "http://www.eb.dk/" );

         // TODO
         throw new NotImplementedException();
      }

      Task<string> CreateFetchTask( string url )
      {
         // TODO
         throw new NotImplementedException();
      }

      void OnComputeClick( object sender, RoutedEventArgs e )
      {
         // TODO

         // tbResult.Text = ...;
      }
   }
}
