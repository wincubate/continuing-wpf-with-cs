using System.Windows;
using System.Windows.Interactivity;

namespace Wincubate.Module12.Slide12
{
    public class MessageBoxAction : TriggerAction<UIElement>
   {
      public MessageBoxAction()
      {
      }

      public string Message
      {
         get;
         set;
      }

      protected override void Invoke( object parameter )
      {
         MessageBox.Show( this.Message );
      }
   }
}
