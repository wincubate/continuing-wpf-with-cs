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

namespace Wincubate.EventAndCommandsExamples.Slide14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region Input Gestures
            //ApplicationCommands.Help.InputGestures.Add(
            //   new MouseGesture( MouseAction.LeftDoubleClick, ModifierKeys.Control )
            //);
            //ApplicationCommands.Help.InputGestures.Add(
            //   new KeyGesture( Key.X, ModifierKeys.Control )
            //);
            #endregion
        }

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            ApplicationCommands.Help.Execute(
               null,
               sender as IInputElement );
        }

        private void CommandBinding_CanExecute( object sender, CanExecuteRoutedEventArgs e )
        {
           e.CanExecute = true;
        }

        private void CommandBinding_Executed( object sender, ExecutedRoutedEventArgs e )
        {
           System.Diagnostics.Process.Start( "http://www.wincubate.net/" );

           e.Handled = true;
        }
    }
}
