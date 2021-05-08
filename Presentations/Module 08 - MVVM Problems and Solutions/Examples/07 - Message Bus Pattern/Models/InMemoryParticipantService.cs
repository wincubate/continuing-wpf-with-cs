using System;
using System.Collections.Generic;
using Wincubate.MvvmPatternsExamples.Data;

namespace Wincubate.MvvmPatternsExamples.Slide07.Models
{
    public class InMemoryParticipantService : IParticipantService
    {
        private Dictionary<int, Participant> _participants;

        public InMemoryParticipantService()
        {
            _participants = new Dictionary<int, Participant>();

            Update(
               new Participant
               (
                   1,
                   "Gulmann Henriksen",
                   "Jesper",
                   "Wincubate ApS"
               )
            );
            Update(
               new Participant
               (
                   2,
                   "Grønfeldt",
                   "Hans",
                   "Codeblenderiet"
               )
            );
            Update(
               new Participant
               (
                   3,
                   "Finsen",
                   "Kim",
                   "Onomatopoietikon A/S"
               )
            );
            Update(
               new Participant
               (
                   4,
                   "Holgersen",
                   "Finn",
                   "Onomatopoietikon A/S"
               )
            );
            Update(
               new Participant
               (
                   5,
                   "Bastrup",
                   "Rasmus",
                   "Onomatopoietikon A/S"
               )
            );
            Update(
               new Participant
               (
                   6,
                   "Sanaa",
                   "Armin",
                   "Onomatopoietikon A/S"
               )
            );
            Update(
               new Participant
               (
                   7,
                   "Besson",
                   "Luc",
                   "Tools for Fools A/S"
               )
            );
            Update(
               new Participant
               (
                   8,
                   "Besson",
                   "Beth",
                   "Tools for Fools A/S"
               )
            );
        }

        public IEnumerable<Participant> GetAll() =>
            _participants.Values;

        public Participant GetById(int id)
        {
            Participant p;
            if (_participants.TryGetValue(id, out p))
            {
                return p;
            }

            throw new ArgumentOutOfRangeException("Id out of range!");
        }

        public void Update(Participant p) =>
            _participants[p.Id] = p;
    }
}
