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
using System.Windows.Interop;

namespace Wincubate.Module11.Slide08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click( object sender, RoutedEventArgs e )
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            WindowInteropHelper helper = new WindowInteropHelper( this );
            OwnerWindow owner = new OwnerWindow();
            owner.Handle = helper.Handle;

            System.Windows.Forms.DialogResult dr = dialog.ShowDialog( owner );

            if( dr == System.Windows.Forms.DialogResult.OK )
            {
                txtFile.Text = dialog.FileName;
            }
        }
    }
}
