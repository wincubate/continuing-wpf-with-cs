﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wincubate.ThreadsAndAsynchronyExamples.Slide16
{
   class Program
   {
      static void Main( string[] args )
      {
         Task<DateTime> t = Task.Run<DateTime>( () => DateTime.Now );

         Console.WriteLine( t.Result );
      }
   }
}
