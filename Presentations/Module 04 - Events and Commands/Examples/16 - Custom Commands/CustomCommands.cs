using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Wincubate.EventAndCommandsExamples.Slide16
{
   public static class CustomCommands
   {
      public static RoutedUICommand Launch
      {
         get;
         private set;
      }

      static CustomCommands()
      {
         InputGestureCollection inputGestures = new InputGestureCollection
            {
                new KeyGesture( Key.L, ModifierKeys.Control )
            };

         Launch = new RoutedUICommand(
            "Sæt i gang",
            "Launch",
            typeof( CustomCommands ),
            inputGestures
         );
      }
   }
}
