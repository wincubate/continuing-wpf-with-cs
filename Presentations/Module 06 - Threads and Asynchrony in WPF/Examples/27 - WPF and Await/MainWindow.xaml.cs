using System.Threading.Tasks;
using System.Windows;

namespace Wincubate.Threading.Module08
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

        private void OnClick(object sender, RoutedEventArgs e)
        {
            PrimeHelper helper = new PrimeHelper();
            int number = int.Parse(txtNumber.Text);
            string result = string.Join("*", helper.GetPrimeFactors(number));

            lblResult.Content = result;
        }

        #region Task-based

        private Task<string> FactorAsync()
        {
            PrimeHelper helper = new PrimeHelper();
            int number = int.Parse(txtNumber.Text);

            return Task.Run(() =>
              string.Join("*", helper.GetPrimeFactors(number))
            );
        }

        #endregion
    }
}
