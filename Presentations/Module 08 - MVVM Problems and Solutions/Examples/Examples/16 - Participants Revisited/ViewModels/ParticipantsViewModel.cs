using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Wincubate.IntroducingMvvmExamples.Data;

namespace Wincubate.IntroducingMvvmExamples.Slide16
{
   public class ParticipantsViewModel : ViewModelBase
   {
      public ObservableCollection<ParticipantViewModel> Participants
      {
         get;
         set;
      }

      #region Commands

      public ICommand AddNew
      {
         get
         {
            if( _addNew == null )
            {
               _addNew = new RelayCommand(
                  parameter => this.AddNewParticipant()
               );
            }
            return _addNew;
         }
      }
      private RelayCommand _addNew;

      public ICommand RemoveFirst
      {
         get
         {
            if( _removeFirst == null )
            {
               _removeFirst = new RelayCommand(
                  parameter => this.RemoveFirstParticipant(),
                  parameter => this.CanRemoveFirstParticipant
               );
            }
            return _removeFirst;
         }
      }
      private RelayCommand _removeFirst;

      public ICommand RemoveSelected
      {
         get
         {
            if( _removeSelected == null )
            {
               _removeSelected = new RelayCommand(
                  parameter => this.RemoveSelectedParticipant( parameter ),
                  parameter => this.CanRemoveSelectedParticipant( parameter )
               );
            }
            return _removeSelected;
         }
      }
      private RelayCommand _removeSelected;

      #endregion 

      public ParticipantsViewModel( Participants participants )
      {
         var ps = new ObservableCollection<ParticipantViewModel>();

         foreach( var p in participants )
         {
            ps.Add( new ParticipantViewModel( p ) );
         }

         Participants = ps;
      }

      #region Helpers

      private void AddNewParticipant()
      {
         Participant participant = new Participant( "Vuns", "Mette", "Quickie-Mart" );
         Participants.Add( new ParticipantViewModel( participant ) );
      }

      public bool CanRemoveFirstParticipant
      {
         get
         {
            return( Participants.Count > 0 );
         }
      }

      private void RemoveFirstParticipant()
      {
         if( CanRemoveFirstParticipant )
         {
            Participants.RemoveAt( 0 );
         }
      }

      public bool CanRemoveSelectedParticipant( object selected )
      {
         return ( selected != null ? Participants.Contains( selected ) : false );
      }

      private void RemoveSelectedParticipant( object selected )
      {
         if( CanRemoveSelectedParticipant( selected ) )
         {
            Participants.Remove( selected as ParticipantViewModel );
         }
      }

      #endregion
   }
}
