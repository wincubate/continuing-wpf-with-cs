using System;
using System.Net;
using System.Threading.Tasks;

namespace Wincubate.Threading.Module08
{
    class Program
    {
        static async Task Main()
        {
            await DoStuffAsync();

            Console.ReadLine();
        }

        async static Task DoStuffAsync()
        {
            string url = "http://www.does-not-exist.nonono";

            try
            {
                WebClient client = new WebClient();
                string result = await client.DownloadStringTaskAsync(url);

                Console.WriteLine(result);
            }
            catch (WebException)
            {
                Console.WriteLine("Something went wrong!");
            }
        }
    }
}
