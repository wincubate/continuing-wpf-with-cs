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

namespace Wincubate.FundamentalsExamples.Slide11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> _items;
        const int itemCount = 999999;

        public MainWindow()
        {
            InitializeComponent();

            InitializeListBox();
        }

        private void InitializeListBox()
        {
            _items = new List<string>( itemCount );
            for( int i = 0; i < itemCount; i++ )
            {
                _items.Add(
                   string.Format( "Item #{0,6}", i )
                );
            }

            this.DataContext = _items;
        }
    }
}
