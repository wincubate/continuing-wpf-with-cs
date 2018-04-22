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
using System.ComponentModel;

namespace Wincubate.DataBindingCollectionsExamples.Slide04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICollectionView _collectionView;

        public MainWindow()
        {
            InitializeComponent();

            _collectionView = CollectionViewSource.GetDefaultView( DataContext );
        }

        private void buttonMoveFirst_Click( object sender, RoutedEventArgs e )
        {
            _collectionView.MoveCurrentToFirst();
        }

        private void buttonMovePrevious_Click( object sender, RoutedEventArgs e )
        {
            _collectionView.MoveCurrentToPrevious();
        }

        private void buttonMoveNext_Click( object sender, RoutedEventArgs e )
        {
            _collectionView.MoveCurrentToNext();
        }

        private void buttonMoveLast_Click( object sender, RoutedEventArgs e )
        {
            _collectionView.MoveCurrentToLast();
        }
    }
}
