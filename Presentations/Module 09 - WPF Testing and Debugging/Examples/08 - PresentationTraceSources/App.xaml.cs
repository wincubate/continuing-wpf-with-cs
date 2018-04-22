using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Diagnostics;

namespace Wincubate.Module12.Slide18
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup( object sender, StartupEventArgs e )
        {
            PresentationTraceSources.Refresh();

            //PresentationTraceSources.DataBindingSource.Listeners.Add(
            //    new TextWriterTraceListener( "DebugProgrammatically.txt" )
            //);
            //PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.All;
        }
    }
}
