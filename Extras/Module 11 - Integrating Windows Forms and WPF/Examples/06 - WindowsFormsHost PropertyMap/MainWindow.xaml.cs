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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Wincubate.Module11.Slide06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set up WindowsFormsHost
            propertyGrid.SelectedObject = this;

            // Add a custom mapping for the Clip property.
            wfHost.PropertyMap.Add(
                "Clip",
                new PropertyTranslator(OnClipChange));
        }

        // The OnClipChange method assigns an elliptical clipping 
        // region to the hosted control's Region property.
        private void OnClipChange(object h, String propertyName, object value)
        {
            WindowsFormsHost host = h as WindowsFormsHost;
            System.Windows.Forms.PropertyGrid pg = host.Child as System.Windows.Forms.PropertyGrid;

            if (pg != null)
            {
                pg.Region = CreateClipRegion();
            }
        }

        // The wfHost_SizeChanged method handles the window's 
        // SizeChanged event. It calls the OnClipChange method explicitly 
        // to assign a new clipping region to the hosted control.
        private void wfHost_SizeChanged( object sender, SizeChangedEventArgs e )
        {
            this.OnClipChange(wfHost, "Clip", null);
        }

        // The CreateClipRegion method creates a Region from an
        // elliptical GraphicsPath.
        private Region CreateClipRegion()
        {   
            GraphicsPath path = new GraphicsPath();

            path.StartFigure(); 

            path.AddEllipse(new System.Drawing.Rectangle( 
                0, 
                0, 
                (int)wfHost.ActualWidth, 
                (int)wfHost.ActualHeight ) );

            path.CloseFigure(); 

            return( new Region(path) );
        }
    }
}
