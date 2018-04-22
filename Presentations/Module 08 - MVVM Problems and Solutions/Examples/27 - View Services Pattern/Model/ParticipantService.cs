using System;
using System.Collections.Generic;
using System.Linq;

namespace Wincubate.MvvmSolutions.Slide27.Model
{
   public class ParticipantService : IParticipantService
   {

      public ParticipantService()
      {
      }

      #region IParticipantService Members

      public void GetAll( Action<IEnumerable<Participant>, Exception> callback )
      {
         try
         {
            using ( ParticipantsEntities _entities = new ParticipantsEntities() )
            {
               var ps = _entities.Participants;
               callback( ps, null );
            }
         }
         catch ( Exception e )
         {
            callback( null, e );
         }
      }

      public void GetById( int id, Action<Participant, Exception> callback )
      {
         try
         {
            using ( ParticipantsEntities _entities = new ParticipantsEntities() )
            {
               var participant = _entities.Participants.Single( p => p.Id == id );
               callback( participant, null );
            }
         }
         catch ( Exception e )
         {
            callback( null, e );
         }
      }

      public void Update( Participant participant, Action<Exception> callback )
      {
         try
         {
            using ( ParticipantsEntities _entities = new ParticipantsEntities() )
            {
               var old = _entities.Participants.Single( item => item.Id == participant.Id );               
               old.FirstName = participant.FirstName;         // Not nice, but demo purpose only... ;-)
               old.LastName = participant.LastName;
               old.Company = participant.Company;

               _entities.SaveChanges();

               callback( null );
            }
         }
         catch ( Exception e )
         {
            callback( e );
         }
      }

      public void Delete( int id, Action<Exception> callback )
      {
         try
         {
            using ( ParticipantsEntities _entities = new ParticipantsEntities() )
            {
               var toBeRemoved = _entities.Participants.Single( item => item.Id == id );
               _entities.Participants.Remove( toBeRemoved );

               _entities.SaveChanges();

               callback( null );
            }
         }
         catch ( Exception e )
         {
            callback( e );
         }
      }

      #endregion
   }
}