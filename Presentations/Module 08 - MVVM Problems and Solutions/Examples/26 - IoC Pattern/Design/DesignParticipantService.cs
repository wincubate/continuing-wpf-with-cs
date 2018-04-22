using System;
using System.Collections.Generic;
using Wincubate.MvvmSolutions.Slide26.Model;

namespace Wincubate.MvvmSolutions.Slide26.Design
{
   public class DesignParticipantService : IParticipantService
   {
      private Dictionary<int,Participant> _participants;

      public DesignParticipantService()
      {
         _participants = new Dictionary<int,Participant>();

         #region Hardcoded Design-mode Data

         _participants[ 1 ] =
            new Participant
            {
               Id = 1,
               LastName = "Gulmann Henriksen",
               FirstName = "Jesper",
               Company = "Wincubate"
            };
         _participants[ 2 ] =
            new Participant
            {
               Id = 2,
               LastName = "Møller Grønfeldt",
               FirstName = "Mads",
               Company = "Codeblend"
            };
         _participants[ 3 ] =
            new Participant
            {
               Id = 3,
               LastName = "Foged",
               FirstName = "Kim",
               Company = "DSE Airport Solutions A/S"
            };
         _participants[ 4 ] =
            new Participant
            {
               Id = 4,
               LastName = "Bjerner",
               FirstName = "Rasmus",
               Company = "DSE Airport Solutions A/S"
            };
         _participants[ 5 ] =
            new Participant
            {
               Id = 5,
               LastName = "Nazarian",
               FirstName = "Armen",
               Company = "DSE Airport Solutions A/S"
            };
         _participants[ 6 ] =
            new Participant
            {
               Id = 6,
               LastName = "Bresson",
               FirstName = "Bo",
               Company = "HRtools A/S"
            };
         _participants[ 7 ] =
            new Participant
            {
               Id = 7,
               LastName = "Bresson",
               FirstName = "Lene Rikke",
               Company = "HRtools A/S"
            };

         #endregion
      }

      public void GetAll( Action<IEnumerable<Participant>, Exception> callback )
      {
         var ps = _participants.Values;
         callback( ps, null );
      }

      public void GetById( int id, Action<Participant, Exception> callback )
      {
         Participant p;
         if ( _participants.TryGetValue( id, out p ) )
         {
            callback( p, null );
         }
         else
         {
            callback( null, new ArgumentOutOfRangeException( "Id out of range!" ) );
         }
      }

      public void Update( Participant p, Action<Exception> callback )
      {
         _participants[ p.Id ] = p;

         callback( null );
      }
   }
}