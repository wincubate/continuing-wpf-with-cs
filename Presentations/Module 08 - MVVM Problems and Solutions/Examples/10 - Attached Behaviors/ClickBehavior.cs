using System.Windows;
using System.Windows.Input;

namespace Wincubate.MvvmPatternsExamples.Slide10
{
    public static class ClickBehavior
   {
      public static DependencyProperty CommandProperty =
          DependencyProperty.RegisterAttached(
              "Command",
              typeof( ICommand ),
              typeof( ClickBehavior ),
              new PropertyMetadata( OnCommandPropertyChanged )
          );

      private static void OnCommandPropertyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
      {
         // Note: When the Command property is set, it is "changed"
         var uiElement = d as UIElement;
         if ( uiElement != null )
         {
            uiElement.MouseDown += OnUIElementMouseDown;
         }
      }

      public static ICommand GetCommand( DependencyObject obj )
      {
         return obj.GetValue( CommandProperty ) as ICommand;
      }

      public static void SetCommand( DependencyObject obj, ICommand value )
      {
         obj.SetValue( CommandProperty, value );
      }

      private static void OnUIElementMouseDown( object sender, MouseButtonEventArgs e )
      {
         DependencyObject d = sender as DependencyObject;

         // Invoke command programmatically         
         ICommand command = GetCommand( d );
         if( command != null )
         {
            if ( command.CanExecute( null ) )
            {
               command.Execute( null );
            }
         }
      }
   }
}
