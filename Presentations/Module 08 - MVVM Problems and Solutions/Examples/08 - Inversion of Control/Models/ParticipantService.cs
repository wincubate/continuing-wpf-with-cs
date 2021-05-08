using System.Collections.Generic;
using System.Linq;
using Wincubate.MvvmPatternsExamples.Data;
using Wincubate.MvvmPatternsExamples.Data.EF;

namespace Wincubate.MvvmPatternsExamples.Slide08.Models
{

    public class ParticipantService : IParticipantService
    {

        public ParticipantService()
        {
        }

        #region IParticipantService Members

        public IEnumerable<Participant> GetAll()
        {
            using (ParticipantsContext context = new ParticipantsContext())
            {
                return context.Participants
                    .ToList();
            }
        }

        public Participant GetById(int id)
        {
            using (ParticipantsContext context = new ParticipantsContext())
            {
                return context.Participants.Single(p => p.Id == id);
            }
        }

        public void Update(Participant participant)
        {
            using (ParticipantsContext context = new ParticipantsContext())
            {
                var old = context.Participants.Single(item => item.Id == participant.Id);
                old.FirstName = participant.FirstName;         // Not nice, but demo purpose only... ;-)
                old.LastName = participant.LastName;
                old.Company = participant.Company;

                context.SaveChanges();
            }
        }

        #endregion
    }
}