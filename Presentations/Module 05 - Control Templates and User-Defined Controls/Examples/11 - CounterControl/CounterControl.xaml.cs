using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wincubate.ControlTemplatesExamples.Slide11
{
   public delegate void CounterChangedEventHandler( object sender, CounterChangedEventArgs e );

   /// <summary>
   /// Interaction logic for UserControl1.xaml
   /// </summary>
   public partial class CounterControl : UserControl
   {
      // WPF dependency property
      public static readonly DependencyProperty CounterProperty;

      static CounterControl()
      {
         // Create WPF dependency property
         FrameworkPropertyMetadata md =
            new FrameworkPropertyMetadata(
               0,
               new PropertyChangedCallback( OnCounterPropertyChanged )
            );
         CounterProperty = DependencyProperty.Register(
            "Counter",
            typeof( int ),
            typeof( CounterControl ),
            md );
      }

      private static void OnCounterPropertyChanged(
         DependencyObject o, DependencyPropertyChangedEventArgs e )
      {
         CounterControl cc = o as CounterControl;
         cc.tbCount.Text = e.NewValue.ToString();

         cc.RaiseCounterChangedEvent();
      }

      // .NET CLR property for dependency property
      public int Counter
      {
         get
         {
            return (int) GetValue( CounterProperty );
         }
         set
         {
            SetValue( CounterProperty, value );
         }
      }

      // WPF routed event
      public static readonly RoutedEvent CounterChangedEvent =
         EventManager.RegisterRoutedEvent(
             "CounterChanged",
             RoutingStrategy.Bubble,
             typeof( CounterChangedEventHandler ),
             typeof( CounterControl ) );

      // .NET event
      public event CounterChangedEventHandler CounterChanged
      {
         add
         {
            AddHandler( CounterChangedEvent, value );
         }
         remove
         {
            RemoveHandler( CounterChangedEvent, value );
         }
      }

      private void RaiseCounterChangedEvent()
      {
         CounterChangedEventArgs newEventArgs = new CounterChangedEventArgs( CounterControl.CounterChangedEvent, this );
         newEventArgs.Value = Counter;
         RaiseEvent( newEventArgs );
      }

      public CounterControl()
      {
         InitializeComponent();
      }

      private void btnIncrement_Click( object sender, RoutedEventArgs e )
      {
         Counter++;
      }

      private void btnDecrement_Click( object sender, RoutedEventArgs e )
      {
         Counter--;
      }
   }
}
