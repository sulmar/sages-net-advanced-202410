using System.Diagnostics;

namespace ThreadExample;

public class EmailMessageService
{
    private Random random = new Random();

    public void SendToMe()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        $"Sending...".DumpThreadId();        

        Thread.Sleep(random.Next(1000, 3000));

        stopwatch.Stop();

        $"Sent. Elapsed time: {stopwatch.Elapsed}".DumpThreadId();
    }

    public void SendTo(string to)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        $"Sending to {to}...".DumpThreadId();

        Thread.Sleep(random.Next(1000, 3000));

        stopwatch.Stop();

        $"Sent to {to}. Elapsed time: {stopwatch.Elapsed}".DumpThreadId();
    }
}
