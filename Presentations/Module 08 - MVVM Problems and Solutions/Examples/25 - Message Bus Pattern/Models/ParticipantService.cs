using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wincubate.MvvmSolutions.Slide25
{
    public class ParticipantService
    {
        private Dictionary<int, Participant> _participants;

        public ParticipantService()
        {
            _participants = new Dictionary<int, Participant>();

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
                   LastName = "Grønfeldt",
                   FirstName = "Hans",
                   Company = "Codeblenderiet"
               }
            );
            Update(
               new Participant
               {
                   Id = 3,
                   LastName = "Finsen",
                   FirstName = "Kim",
                   Company = "Onomatopoietikon A/S"
               }
            );
            Update(
               new Participant
               {
                   Id = 4,
                   LastName = "Finsen",
                   FirstName = "Kim",
                   Company = "Onomatopoietikon A/S"
               }
            );
            Update(
               new Participant
               {
                   Id = 5,
                   LastName = "Bastrup",
                   FirstName = "Rasmus",
                   Company = "Onomatopoietikon A/S"
               }
            );
            Update(
               new Participant
               {
                   Id = 6,
                   LastName = "Sanaa",
                   FirstName = "Armin",
                   Company = "Onomatopoietikon A/S"
               }
            );
            Update(
               new Participant
               {
                   Id = 7,
                   LastName = "Besson",
                   FirstName = "Luc",
                   Company = "Tools for Fools A/S"
               }
            );
            Update(
               new Participant
               {
                   Id = 7,
                   LastName = "Besson",
                   FirstName = "Beth",
                   Company = "Tools for Fools A/S"
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
            if (_participants.TryGetValue(id, out p))
            {
                return p;
            }

            throw new ArgumentOutOfRangeException("Id out of range!");
        }

        public void Update( Participant p )
        {
            _participants[p.Id] = p;
        }
    }
}
