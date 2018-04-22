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

namespace Wincubate.DataBindingPropertiesExamples.Slide03
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

        private void OnCreateClick( object sender, RoutedEventArgs e )
        {
            Binding binding = new Binding();
            binding.ElementName = "slider";
            binding.Path = new PropertyPath( "Value" );
            label.SetBinding( ContentProperty, binding );
        }

        private void OnClearClick( object sender, RoutedEventArgs e )
        {
            BindingOperations.ClearBinding( label, ContentProperty );
        }
    }
}
