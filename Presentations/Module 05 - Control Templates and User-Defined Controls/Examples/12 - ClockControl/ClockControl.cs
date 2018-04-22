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

namespace Wincubate.ControlTemplatesExamples.Slide12
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Wincubate.ControlTemplatesExamples.Slide12"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Wincubate.ControlTemplatesExamples.Slide12;assembly=Wincubate.ControlTemplatesExamples.Slide12"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class ClockControl : Control
    {
        // WPF dependency property
        public static readonly DependencyProperty TimeProperty;

        static ClockControl()
        {
            // Inserted by VS 2012 Project Wizard
            DefaultStyleKeyProperty.OverrideMetadata( typeof( ClockControl ), new FrameworkPropertyMetadata( typeof( ClockControl ) ) );

            // Create WPF dependency property
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            TimeProperty = DependencyProperty.Register(
               "Time",
               typeof( string ),
               typeof( ClockControl ),
               metadata
            );
        }

        System.Timers.Timer _timer = new System.Timers.Timer();

        // .NET CLR property
        public string Time
        {
            get
            {
                return GetValue( TimeProperty ) as string;
            }
        }

        void TimeSet()
        {
            SetValue( TimeProperty, DateTime.Now.ToLongTimeString() );
        }

        public ClockControl()
        {
            _timer.Elapsed += OnTimerElapsed;
            _timer.Interval = 1000;
            _timer.Start();
        }

        void OnTimerElapsed( object sender, System.Timers.ElapsedEventArgs e )
        {
            Dispatcher.Invoke(
               System.Windows.Threading.DispatcherPriority.Render,
               new Action( TimeSet )
            );
        }
    }
}
