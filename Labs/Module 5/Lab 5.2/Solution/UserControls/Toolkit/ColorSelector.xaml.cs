using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Toolkit
{
   /// <summary>
   /// Interaction logic for UserControl1.xaml
   /// </summary>
   public partial class ColorSelector : UserControl
   {
      // .NET CLR property for dependency property
      public Color Color
      {
         get { return (Color)GetValue( ColorProperty ); }
         set { SetValue( ColorProperty, value ); }
      }

      // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty ColorProperty =
          DependencyProperty.Register(
              "Color",
              typeof( Color ),
              typeof( ColorSelector ),
              new FrameworkPropertyMetadata( Colors.Black, new PropertyChangedCallback ( OnColorChanged ) )
          );

      private static void OnColorChanged( DependencyObject o, DependencyPropertyChangedEventArgs e )
      {
         ColorSelector cs = o as ColorSelector;
         if( cs != null )
         {
            Color newColor = (Color)e.NewValue;
            Color oldColor = (Color)e.OldValue;

            cs.PaintRectangle( newColor );

            cs.red.Value = newColor.R;
            cs.green.Value = newColor.G;
            cs.blue.Value = newColor.B;

            // Raise routed event
            cs.RaiseColorChangedEvent( oldColor, newColor );
         }
      }

      // WPF routed event
      public static readonly RoutedEvent ColorChangedEvent =
         EventManager.RegisterRoutedEvent(
             "ColorChanged",
             RoutingStrategy.Bubble,
             typeof( RoutedPropertyChangedEventHandler<Color> ),
             typeof( ColorSelector ) );

      // .NET event wrapper
      public event RoutedPropertyChangedEventHandler<Color> ColorChanged
      {
         add
         {
            AddHandler( ColorChangedEvent, value );
         }
         remove
         {
            RemoveHandler( ColorChangedEvent, value );
         }
      }

      private void RaiseColorChangedEvent( Color oldColor, Color newColor )
      {
         RoutedPropertyChangedEventArgs<Color> e = new RoutedPropertyChangedEventArgs<Color>( oldColor, newColor, ColorSelector.ColorChangedEvent );
         RaiseEvent( e );
      }

      public ColorSelector()
      {
         InitializeComponent();
      }


      private void OnLoaded( object sender, RoutedEventArgs e )
      {
         PaintRectangle( Color );
      }

      private void OnValueChanged( object sender, RoutedPropertyChangedEventArgs<double> e )
      {
         byte r = (byte)red.Value;
         byte g = (byte)green.Value;
         byte b = (byte)blue.Value;

         Color = Color.FromRgb( r, g, b );
      }

      private void PaintRectangle( Color c )
      {
         rectangle.Fill = new SolidColorBrush( c );
      }
   }
}
