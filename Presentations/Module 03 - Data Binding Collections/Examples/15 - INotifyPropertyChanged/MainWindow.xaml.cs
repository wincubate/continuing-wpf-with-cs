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
using Wincubate.DataBindingCollectionsExamples.Data;
using System.Threading;

namespace Wincubate.DataBindingCollectionsExamples.Slide15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Thread _thread = null;
        Participants _participants = new Participants();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _participants;
        }

        private void btnModify_Click( object sender, RoutedEventArgs e )
        {
            Participant participant = _participants[ 0 ];
            participant.FirstName = "Mario";
        }

        private void btnAdd_Click( object sender, RoutedEventArgs e )
        {
            Participant participant = new Participant( "Vuns", "Mette", "Quickie-Mart" );
            _participants.Add( participant );
        }

        //private void btnThreadAdd_Click( object sender, RoutedEventArgs e )
        //{
        //    _thread = new Thread( () =>
        //        _participants.Add( new Participant( "Child", "Problem", "Trouble A/S" ) )
        //    );
        //    _thread.Start();
        //}
    }
}
