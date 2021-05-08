using System.Diagnostics;
using System.Threading;
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

        async private void OnClick(object sender, RoutedEventArgs e)
        {
            Log("Before");

            string result = await FactorAsync();
            lblResult.Content = result;

            Log("After");
        }

        #region Task-based

        private Task<string> FactorAsync()
        {
            PrimeHelper helper = new PrimeHelper();
            int number = int.Parse(txtNumber.Text);

            return Task.Run(() =>
            {
                Trace.WriteLine($"During - {Thread.CurrentThread.ManagedThreadId}");

                return string.Join("*", helper.GetPrimeFactors(number));
            }
            );
        }

        #endregion

        private void Log(string message)
        {
            string logLine = $"{message} - {Thread.CurrentThread.ManagedThreadId}";
            lst.Items.Add(logLine);
        }
    }
}
