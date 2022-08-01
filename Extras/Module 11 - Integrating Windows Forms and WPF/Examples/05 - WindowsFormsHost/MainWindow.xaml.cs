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

namespace Wincubate.Module11.Slide05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           System.Windows.Forms.Application.EnableVisualStyles();
           
           InitializeComponent();

            //System.Windows.Forms.Integration.WindowsFormsHost host =
            //    new System.Windows.Forms.Integration.WindowsFormsHost();
            //System.Windows.Forms.PropertyGrid propertyGrid =
            //    new System.Windows.Forms.PropertyGrid();
            
            //propertyGrid.SelectedObject = this;
            //host.Child = propertyGrid;

            //layoutRoot.Children.Add( host );
        }

        private void mtb_MaskInputRejected( object sender, System.Windows.Forms.MaskInputRejectedEventArgs e )
        {
            MessageBox.Show( "No way!" );
        }
    }
}
