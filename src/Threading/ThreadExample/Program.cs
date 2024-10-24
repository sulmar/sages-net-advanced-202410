using System.Diagnostics;
using System.Net;
using ThreadExample;

Console.WriteLine("Hello, Thread!");

 SendEmailTest();

// DownloadTest();

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

static void DownloadTest()
{
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
}

static void SendEmailTest()
{
    EmailMessageService messageService = new EmailMessageService();

    "Started".DumpThreadId();

    Stopwatch stopwatch = Stopwatch.StartNew();

    IEnumerable<Thread> threads = Enumerable.Range(1, 100)
        .Select(_ => new Thread(() => messageService.SendTo("john.smith@domain.com")));

    foreach (Thread thread in threads)
    {
        thread.Start();        
    }

    stopwatch.Stop();

    $"Sent all. Elapsed time: {stopwatch.Elapsed}".DumpThreadId();    
}