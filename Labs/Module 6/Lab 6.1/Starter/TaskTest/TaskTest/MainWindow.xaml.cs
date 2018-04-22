using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
      Task<int> ComputeLengthSum()
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
