using System;
using System.Collections.Generic;
using Wincubate.MvvmSolutions.Slide26.Model;

namespace Wincubate.MvvmSolutions.Slide26.Design
{
    public class DesignParticipantService : IParticipantService
    {
        private Dictionary<int, Participant> _participants;

        public DesignParticipantService()
        {
            _participants = new Dictionary<int, Participant>();

            #region Hardcoded Design-mode Data

            _participants[1] =
               new Participant
               {
                   Id = 1,
                   LastName = "Gulmann Henriksen",
                   FirstName = "Jesper",
                   Company = "Wincubate"
               };
            _participants[2] =
               new Participant
               {
                   Id = 2,
                   LastName = "Grønfeldt",
                   FirstName = "Hans",
                   Company = "Codeblenderiet"
               };
            _participants[3] =
               new Participant
               {
                   Id = 3,
                   LastName = "Finsen",
                   FirstName = "Kim",
                   Company = "Onomatopoietikon A/S"
               };
            _participants[4] =
               new Participant
               {
                   Id = 4,
                   LastName = "Finsen",
                   FirstName = "Kim",
                   Company = "Onomatopoietikon A/S"
               };
            _participants[5] =
               new Participant
               {
                   Id = 5,
                   LastName = "Bastrup",
                   FirstName = "Rasmus",
                   Company = "Onomatopoietikon A/S"
               };
            _participants[6] =
               new Participant
               {
                   Id = 6,
                   LastName = "Sanaa",
                   FirstName = "Armin",
                   Company = "Onomatopoietikon A/S"
               };
            _participants[7] =
               new Participant
               {
                   Id = 7,
                   LastName = "Besson",
                   FirstName = "Luc",
                   Company = "Tools for Fools A/S"
               };
            _participants[8] =
               new Participant
               {
                   Id = 7,
                   LastName = "Besson",
                   FirstName = "Beth",
                   Company = "Tools for Fools A/S"
               };

            #endregion
        }

        public void GetAll( Action<IEnumerable<Participant>, Exception> callback )
        {
            var ps = _participants.Values;
            callback(ps, null);
        }

        public void GetById( int id, Action<Participant, Exception> callback )
        {
            Participant p;
            if (_participants.TryGetValue(id, out p))
            {
                callback(p, null);
            }
            else
            {
                callback(null, new ArgumentOutOfRangeException("Id out of range!"));
            }
        }

        public void Update( Participant p, Action<Exception> callback )
        {
            _participants[p.Id] = p;

            callback(null);
        }
    }
}