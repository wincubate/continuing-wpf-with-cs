using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TroelsBechQuotes.Pcl.Services
{
   /// <summary>
   /// Represents the result of a message being displayed to the user.
   /// </summary>
   public enum DialogResult
   {
      None = 0,
      OK = 1,
      Cancel = 2,
      Yes = 6,
      No = 7
   }
}
