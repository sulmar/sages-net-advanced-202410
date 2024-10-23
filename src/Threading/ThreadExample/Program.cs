using System.Diagnostics;
using System.Net;
using ThreadExample;

Console.WriteLine("Hello, Thread!");

const string defaultUri = "https://picsum.photos/800/600";
const int count = 100;

// Wygenerowanie listy adresów url
string[] urls = Enumerable.Range(0, count).Select(_ => defaultUri).ToArray();

Stopwatch stopwatch = Stopwatch.StartNew();

foreach (string url in urls)
{
    Download(url);
}

stopwatch.Stop();

Console.WriteLine("All downloads completed.");

Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");


static void Download(string url)
{
    using (var client = new WebClient())
    {
        $"Downloading {url}...".DumpThreadId();

        // Symulacja opóźnienia
        Thread.Sleep(Random.Shared.Next(200, 1000));

        $"Downoladed. {url}".DumpThreadId();
    }
}
