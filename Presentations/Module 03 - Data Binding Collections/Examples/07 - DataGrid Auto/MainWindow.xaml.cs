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

namespace Wincubate.DataBindingCollectionsExamples.Slide07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            dataGrid.ItemsSource = new Record[] // new List<Record>
            {
                new Record { FirstName="Adam", LastName="Nathan", Website=new Uri("http://adamnathan.net"), Gender=Gender.Male },
                new Record { FirstName="Bill", LastName="Gates", Website=new Uri("http://twitter.com/billgates"), Gender=Gender.Male, IsBillionaire=true }
            };
        }

        private void dataGrid_RequestNavigate( object sender, RequestNavigateEventArgs e )
        {
            MessageBox.Show( "Navigating to " + e.Uri );
        }

        private void dataGrid_AutoGeneratingColumn(
           object sender, DataGridAutoGeneratingColumnEventArgs e )
        {
           if( e.PropertyName == "FirstName" )
           {
              //e.Cancel = true;
              e.Column.Header = "Dude's Name";
           }
        }

        private void dataGrid_InitializingNewItem( object sender, InitializingNewItemEventArgs e )
        {
           Record newRecord = e.NewItem as Record;

           newRecord.FirstName = "Jesper";
           newRecord.LastName = "Gulmann";
           newRecord.Website = new Uri( "http://www.wincubate.net" );
           newRecord.Gender = Gender.Male;
        }
    }
}
