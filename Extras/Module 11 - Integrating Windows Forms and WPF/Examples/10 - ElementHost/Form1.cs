using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Controls;

namespace Wincubate.Module11.Slide10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Expander expander = new Expander();
            expander.Header = "WPF Expander";
            expander.Content = "This is WPF content";
            expander.Expanded += new System.Windows.RoutedEventHandler( OnExpanderChanged );
            expander.Collapsed += new System.Windows.RoutedEventHandler( OnExpanderChanged );
            elementHost.Child = expander;
        }

        void OnExpanderChanged( object sender, System.Windows.RoutedEventArgs e )
        {
            Expander expander = sender as Expander;
            if( expander != null )
            {
                lblExpanded.Text = ( expander.IsExpanded ? "Expanded" : "Collapsed" );
            }
        }
    }
}
