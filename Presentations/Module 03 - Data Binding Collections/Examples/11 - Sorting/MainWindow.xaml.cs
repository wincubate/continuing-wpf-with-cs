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

namespace Wincubate.DataBindingCollectionsExamples.Slide11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //// Generally for ICollectionView
            //ICollectionView collectionView = CollectionViewSource.GetDefaultView( DataContext );
            //collectionView.SortDescriptions.Add(
            //   new SortDescription( "FirstName", ListSortDirection.Ascending )
            //);
            //collectionView.SortDescriptions.Add(
            //   new SortDescription( "Company", ListSortDirection.Ascending )
            //);

            //// Specifically for ListCollectionView
            //ListCollectionView listCollectionView = CollectionViewSource.GetDefaultView( DataContext ) as ListCollectionView;
            //listCollectionView.CustomSort = new Wincubate.Module06.Data.ParticipantComparer();
        }
    }
}
