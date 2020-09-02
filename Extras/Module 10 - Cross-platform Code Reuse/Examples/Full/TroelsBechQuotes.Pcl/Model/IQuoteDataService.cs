using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TroelsBechQuotes.Pcl.Model
{
   public interface IQuoteDataService
   {
      Quote GetRandomQuote();
   }
}
