using System.Diagnostics;
using System.Net;
using ThreadPoolExample;

Console.WriteLine("Hello, Thread Pool!");
Console.WriteLine("Hello, Thread!");

const string defaultUri = "https://picsum.photos/800/600";
const int count = 100;

// Wygenerowanie listy adresów url
string[] urls = Enumerable.Range(0, count).Select(_ => defaultUri).ToArray();

Stopwatch stopwatch = Stopwatch.StartNew();

foreach (string url in urls)
{
    // Thread sendThread = new Thread(()=> Download(url));
    // sendThread.Start();

    ThreadPool.QueueUserWorkItem<string>(Download, url, false);
}

stopwatch.Stop();

Console.WriteLine("All downloads completed.");

Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");

Console.WriteLine("Press any key to exit.");
Console.ReadKey();

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

