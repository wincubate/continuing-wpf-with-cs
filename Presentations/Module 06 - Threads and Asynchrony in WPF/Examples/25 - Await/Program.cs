using System;
using System.Net;

namespace Wincubate.Threading.Module08
{
    class Program
    {
        static void Main()
        {
            DoStuff();

            Console.ReadLine();
        }

        async static void DoStuff()
        {
            string url = "http://www.jp.dk";

            WebClient client = new WebClient();
            string result = await client.DownloadStringTaskAsync(url);

            Console.WriteLine(result);
        }
    }
}
