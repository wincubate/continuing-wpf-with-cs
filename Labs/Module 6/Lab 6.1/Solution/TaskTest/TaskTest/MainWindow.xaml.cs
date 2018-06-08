using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;

namespace TaskTest
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

        Task<int> ComputeLengthSumAsync()
        {
            Task<string> t1 = CreateFetchTask( "http://www.jp.dk/" );
            Task<string> t2 = CreateFetchTask( "http://www.bt.dk/" );
            Task<string> t3 = CreateFetchTask( "http://www.eb.dk/" );

            return Task
                   .WhenAll( t1, t2, t3 )
                   .ContinueWith( ts => ts.Result.Sum( s => s.Length ) );
        }

        Task<string> CreateFetchTask( string url )
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadStringTaskAsync( url );
            }
        }

        async void OnComputeClick( object sender, RoutedEventArgs e )
        {
            tbResult.Text = "The sum of the document lengths are " + await ComputeLengthSumAsync();
        }
    }
}
