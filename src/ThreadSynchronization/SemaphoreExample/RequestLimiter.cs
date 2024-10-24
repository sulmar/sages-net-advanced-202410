namespace SemaphoreExample;

internal class RequestLimiter
{
    private readonly Semaphore _semaphore;

    public RequestLimiter(int maxConcurrentRequests)
    {
        _semaphore = new Semaphore(maxConcurrentRequests, maxConcurrentRequests);
    }

    public void ProcessRequest(int requestId)
    {
        Console.WriteLine($"Request {requestId} is waiting to be processed.");

        _semaphore.WaitOne();

        try
        {
            Console.WriteLine($"Processing request {requestId}");
            // Simulate some work being done
            Thread.Sleep(2000);
        }
        finally
        {
            Console.WriteLine($"Request {requestId} is processed.");

            _semaphore.Release();

        }
    }
}