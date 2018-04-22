using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wincubate.MvvmSolutions.Slide25
{
   public class ParticipantService
   {
      private Dictionary<int,Participant> _participants;

      public ParticipantService()
      {
         _participants = new Dictionary<int,Participant>();

         Update(
            new Participant
            {
               Id = 1,
               LastName = "Gulmann Henriksen",
               FirstName = "Jesper",
               Company = "Wincubate"
            }
         );
         Update(
            new Participant
            {
               Id = 2,
               LastName = "Møller Grønfeldt",
               FirstName = "Mads",
               Company = "Codeblend"
            }
         );
         Update(
            new Participant
            {
               Id = 3,
               LastName = "Foged",
               FirstName = "Kim",
               Company = "DSE Airport Solutions A/S"
            }
         );
         Update( new Participant
            {
               Id = 4,
               LastName = "Bjerner",
               FirstName = "Rasmus",
               Company = "DSE Airport Solutions A/S"
            }
         );
         Update( new Participant
            {
               Id = 5,
               LastName = "Nazarian",
               FirstName = "Armen",
               Company = "DSE Airport Solutions A/S"
            }
         );
         Update( new Participant
            {
               Id = 6,
               LastName = "Bresson",
               FirstName = "Bo",
               Company = "HRtools A/S"
            }
         );
         Update( new Participant
            {
               Id = 7,
               LastName = "Bresson",
               FirstName = "Lene Rikke",
               Company = "HRtools A/S"
            }
         );
      }

      public IEnumerable<Participant> GetAll()
      {
         return _participants.Values;
      }

      public Participant GetById( int id )
      {
         Participant p;
         if( _participants.TryGetValue( id, out p ) )
         {
            return p;
         }

         throw new ArgumentOutOfRangeException( "Id out of range!" );
      }

      public void Update( Participant p )
      {
         _participants[ p.Id ] = p;
      }
   }
}
