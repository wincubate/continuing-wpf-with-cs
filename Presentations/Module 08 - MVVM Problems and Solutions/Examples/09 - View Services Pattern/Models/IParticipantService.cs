using System.Collections.Generic;
using Wincubate.MvvmPatternsExamples.Data;

namespace Wincubate.MvvmPatternsExamples.Slide09.Models
{
    public interface IParticipantService
    {
        IEnumerable<Participant> GetAll();
        Participant GetById(int id);
        void Update(Participant p);
    }
}
