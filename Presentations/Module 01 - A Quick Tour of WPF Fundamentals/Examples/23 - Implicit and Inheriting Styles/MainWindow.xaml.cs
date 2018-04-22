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

namespace Wincubate.FundamentalsExamples.Slide23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Style style = new Style();

            Setter setter = new Setter();
            setter.Property = Label.BackgroundProperty;
            setter.Value = Brushes.Cornsilk;
            style.Setters.Add( setter );

            Setter setter2 = new Setter();
            setter2.Property = Label.RenderTransformProperty;
            setter2.Value = new SkewTransform( 10, 20 );
            style.Setters.Add( setter2 );

            label.Style = style;
        }
    }
}
