using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wincubate.MvvmSolutions.Slide26.Messages
{
   public class ParticipantUpdatedMessage
   {
      public int ParticipantId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Company { get; set; }
   }
}
