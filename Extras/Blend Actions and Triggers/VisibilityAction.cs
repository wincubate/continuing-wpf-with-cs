using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace Wincubate.Module12.Slide12
{
    [TypeConstraint(typeof(ToggleButton))]
    public class VisibilityAction : TargetedTriggerAction<UIElement>
    {
        public VisibilityAction()
        {
        }

        protected override void Invoke(object parameter)
        {
            if ((this.AssociatedObject is ToggleButton toggle) &&
                (toggle.IsChecked.HasValue == true))
            {
                this.Target.Visibility =
                   (toggle.IsChecked.Value ?
                      Visibility.Visible :
                      Visibility.Collapsed);
            }
        }
    }
}
