using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wincubate.MvvmSolutions.Slide27.Model
{
   public interface IParticipantService
   {
      void GetAll( Action<IEnumerable<Participant>, Exception> callback );
      void GetById( int id, Action<Participant, Exception> callback );
      void Update( Participant p, Action<Exception> callback );
      void Delete( int id, Action<Exception> callback );
   }
}
