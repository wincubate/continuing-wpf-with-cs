using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wincubate.MvvmSolutions.Slide27.Services
{
   public interface IDialogService
   {
      bool Prompt( string message, string caption );
   }
}
