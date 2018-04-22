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

namespace Wincubate.FundamentalsExamples.Slide27
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //DoubleAnimation animation = new DoubleAnimation();
            //animation.From = 10;
            //animation.To = 50;
            //animation.Duration = new Duration(new TimeSpan(0, 0, 3));
            ////animation.AutoReverse = true;
            ////animation.RepeatBehavior = RepeatBehavior.Forever;

            //button3.BeginAnimation(Button.HeightProperty, animation);
        }
    }
}
