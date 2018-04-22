using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wincubate.MvvmSolutions.Slide26.Model
{
   public interface IParticipantService
   {
      void GetAll( Action<IEnumerable<Participant>, Exception> callback );
      void GetById( int id, Action<Participant, Exception> callback );
      void Update( Participant p, Action<Exception> callback );
   }
}
