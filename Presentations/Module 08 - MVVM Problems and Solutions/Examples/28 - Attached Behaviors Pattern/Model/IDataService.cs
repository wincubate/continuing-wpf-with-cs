using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wincubate.MvvmSolutions.Slide28.Model
{
   public interface IDataService
   {
      void GetData( Action<DataItem, Exception> callback );
   }
}
