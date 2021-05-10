using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Input;

namespace Wincubate.Module12.Slide12
{
   public class MouseClickTrigger : TriggerBase<UIElement>
   {
      public MouseClickTrigger()
      {
      }

      protected override void OnAttached()
      {
         this.AssociatedObject.MouseLeftButtonDown += this.OnTriggerClick;
      }

      protected override void OnDetaching()
      {
         this.AssociatedObject.MouseLeftButtonDown -= this.OnTriggerClick;
      }

      private void OnTriggerClick( object sender, MouseButtonEventArgs e )
      {
         this.InvokeActions( e );
      }
   }
}
