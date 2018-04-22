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
using Wincubate.ThreadsAndAsynchronyExamples.Data;
using System.Threading;

namespace Wincubate.ThreadsAndAsynchronyExamples.Slide09
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      Thread _threadM = null;
      Thread _threadA = null;
      Participants _participants = new Participants();

      private object _syncObject = new object();

      public MainWindow()
      {
         InitializeComponent();

         DataContext = _participants;

         //BindingOperations.EnableCollectionSynchronization( _participants, _syncObject );
      }

      private void OnModifyClick( object sender, RoutedEventArgs e )
      {
         Participant participant = _participants[ 0 ];
         participant.FirstName = "Mario";
      }

      private void OnThreadModifyClick( object sender, RoutedEventArgs e )
      {
         _threadM = new Thread( () =>
            {
               Participant participant = _participants[ 0 ];
               participant.FirstName = "Ouch";
            }
         );
         _threadM.Start();
      }

      private void OnAddClick( object sender, RoutedEventArgs e )
      {
         Participant participant = new Participant( "Vuns", "Mette", "Quickie-Mart" );
         _participants.Add( participant );
      }

      private void OnThreadAddClick( object sender, RoutedEventArgs e )
      {
         _threadA = new Thread( () =>
             _participants.Add( new Participant( "Child", "Problem", "Trouble A/S" ) )
         );
         _threadA.Start();
      }
   }
}
