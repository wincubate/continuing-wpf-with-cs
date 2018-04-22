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

namespace Wincubate.DataBindingCollectionsExamples.Slide13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ICollectionView collectionView = CollectionViewSource.GetDefaultView( DataContext );
            collectionView.GroupDescriptions.Add(
               new PropertyGroupDescription( "Company", new Wincubate.DataBindingCollectionsExamples.Data.ParticipantsGrouper() )
            );

            collectionView.SortDescriptions.Add( new SortDescription( "Company", ListSortDirection.Ascending ) );

            collectionView.Filter = Wincubate.DataBindingCollectionsExamples.Data.Participant.CustomFilter;
        }
    }
}
