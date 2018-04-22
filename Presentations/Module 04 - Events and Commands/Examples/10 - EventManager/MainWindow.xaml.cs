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

namespace Wincubate.EventAndCommandsExamples.Slide10
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      #region Class-level event handlers

      //static MainWindow()
      //{
      //   EventManager.RegisterClassHandler(
      //      typeof( MainWindow ),
      //      YeahTextBox.YeahEvent,
      //      new RoutedEventHandler(OnClassYeah));
      //}

      //private static void OnClassYeah(object sender, RoutedEventArgs e)
      //{
      //   MessageBox.Show("Everybody say 'Yeah'!");
      //}

      #endregion

      public MainWindow()
      {
         InitializeComponent();
      }

      private void Window_Yeah( object sender, RoutedEventArgs e )
      {
         YeahTextBox ytb = e.Source as YeahTextBox;

         listBox.Items.Add( ytb.Text );
      }
   }
}
