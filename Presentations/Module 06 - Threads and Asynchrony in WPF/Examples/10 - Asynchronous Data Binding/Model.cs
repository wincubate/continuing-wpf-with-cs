using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Wincubate.ThreadsAndAsynchronyExamples.Slide10
{
   public class Model
   {
      public string Fastest
      {
         get
         {
            return ComputeApproximation( 5 );
         }
      }

      public string Fast
      {
         get
         {
            return ComputeApproximation( 30 );
         }
      }

      public string Normal
      {
         get
         {
            return ComputeApproximation( 50 );
         }
      }

      public string Slow
      {
         get
         {
            return ComputeApproximation( 75 );
         }
      }

      public string Slowest
      {
         get
         {
            return ComputeApproximation( 100 );
         }
      }

      private string ComputeApproximation( int percentage, [CallerMemberName] string caller = null )
      {
         // Emulate slow computation...
         Thread.Sleep( percentage * 100 );

         return string.Format( "{2}:\t{0}\tThread Id={1}",
            caller,
            Thread.CurrentThread.ManagedThreadId,
            DateTime.Now
         );
      }
   }
}
