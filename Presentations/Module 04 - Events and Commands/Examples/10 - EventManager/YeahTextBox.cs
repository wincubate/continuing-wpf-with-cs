using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Wincubate.EventAndCommandsExamples.Slide10
{
   public class YeahTextBox : TextBox
   {
      // WPF routed event
      public static readonly RoutedEvent YeahEvent =
         EventManager.RegisterRoutedEvent(
             "Yeah",
             RoutingStrategy.Bubble,
             typeof( RoutedEventHandler ),
             typeof( YeahTextBox ) );

      // .NET event
      public event RoutedEventHandler Yeah
      {
         add
         {
            AddHandler( YeahEvent, value );
         }
         remove
         {
            RemoveHandler( YeahEvent, value );
         }
      }

      private void RaiseYeahEvent()
      {
         RoutedEventArgs newEventArgs = new RoutedEventArgs( YeahTextBox.YeahEvent, this );
         RaiseEvent( newEventArgs );
      }

      protected override void OnTextChanged( TextChangedEventArgs e )
      {
         base.OnTextChanged( e );

         if( this.Text.Contains( "Yeah" ) )
         {
            RaiseYeahEvent();
         }
      }
   }
}
