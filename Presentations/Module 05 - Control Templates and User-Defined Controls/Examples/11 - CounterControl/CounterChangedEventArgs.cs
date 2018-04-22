using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Wincubate.ControlTemplatesExamples.Slide11
{
   public class CounterChangedEventArgs : RoutedEventArgs
   {
      public int Value
      {
         get;
         set;
      }

      public CounterChangedEventArgs()
         : base()
      {
      }

      public CounterChangedEventArgs( RoutedEvent routedEvent )
         : base( routedEvent )
      {
      }

      public CounterChangedEventArgs( RoutedEvent routedEvent, object source )
         : base( routedEvent, source )
      {
      }
   }
}
