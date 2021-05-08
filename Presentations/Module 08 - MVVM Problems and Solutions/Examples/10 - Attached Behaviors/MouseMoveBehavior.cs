using System.Windows;
using System.Windows.Interactivity;

namespace Wincubate.MvvmPatternsExamples.Slide10
{
    public class MouseMoveBehavior : Behavior<UIElement>
   {
      public static DependencyProperty XProperty =
          DependencyProperty.Register(
              "X",
              typeof( int ),
              typeof( MouseMoveBehavior ) 
          );
      public static DependencyProperty YProperty =
          DependencyProperty.Register(
              "Y",
              typeof( int ),
              typeof( MouseMoveBehavior )
          );

      // CLR version of dependency property
      public int X
      {
         get { return (int)GetValue( XProperty ); }
         set { SetValue( XProperty, value ); }
      }
      public int Y
      {
         get { return (int)GetValue( YProperty ); }
         set { SetValue( YProperty, value ); }
      }

      protected override void OnAttached()
      {
         AssociatedObject.MouseMove += OnMouseMove;
         base.OnAttached();
      }

      void OnMouseMove( object sender, System.Windows.Input.MouseEventArgs e )
      {
         Point position = e.GetPosition( sender as IInputElement );
         X = (int) position.X;
         Y = (int) position.Y;
      }

      protected override void OnDetaching()
      {
         AssociatedObject.MouseMove -= OnMouseMove;
         base.OnDetaching();
      }
   }
}
