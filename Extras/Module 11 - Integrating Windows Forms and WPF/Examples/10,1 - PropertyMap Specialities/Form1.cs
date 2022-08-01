using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Forms.Integration;

namespace Wincubate.Module11.Slide10
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();

         // Define WPF content
         Expander expander = new Expander();
         expander.Header = "WPF Expander";
         expander.Content = "This is WPF content";
         elementHost1.Child = expander;

         //elementHost1.PropertyMap.Remove( "BackColor" );
         //elementHost1.PropertyMap.Add(
         //   "BackColor",
         //   new PropertyTranslator( OnBackColorChange )
         //);
         //elementHost1.PropertyMap[ "BackColor" ] +=
         //   new PropertyTranslator( OnBackColorChange );
      }

      private void OnBackColorChange( object sender, string property, object value )
      {
         ElementHost host = sender as ElementHost;
         System.Drawing.Color color = (System.Drawing.Color) value;
         System.Windows.Media.SolidColorBrush brush = new System.Windows.Media.SolidColorBrush(
            System.Windows.Media.Color.FromRgb(
               color.R,
               color.G,
               color.B
            )
         );
         System.Windows.Controls.Control control = host.Child as System.Windows.Controls.Control;
         control.Background = brush;
      }

      private void btnChange_Click( object sender, EventArgs e )
      {
         Random random = new Random();
         this.BackColor = Color.FromArgb(
            random.Next( 256 ),
            random.Next( 256 ),
            random.Next( 256 )
         );

         //elementHost1.PropertyMap.Apply( "BackColor" );
      }
   }
}
