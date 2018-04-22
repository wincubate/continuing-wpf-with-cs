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

namespace Wincubate.EventAndCommandsExamples.Slide09
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      public Window1()
      {
         InitializeComponent();

         //this.AddHandler(
         //   Button.ClickEvent,
         //   new RoutedEventHandler(IllusiveClickHandler),
         //   true
         //);
      }

      private void IllusiveClickHandler(object sender, RoutedEventArgs e)
      {
         MessageBox.Show("Pure magic! ;-)");
      }

      private void OnButtonClicked(object sender, RoutedEventArgs e)
      {
         Button button = e.Source as Button;
         if (button != null)
         {
            MessageBox.Show(button.Content + " was clicked @ " + sender.ToString() );
         }

         //e.Handled = true;
      }
   }
}
