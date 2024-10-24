﻿namespace SemaphoreSlimExample;

internal class RequestLimiter
{
    private readonly SemaphoreSlim _semaphore;

    public RequestLimiter(int maxConcurrentRequests)
    {
        _semaphore = new SemaphoreSlim(maxConcurrentRequests, maxConcurrentRequests);
    }

    public async Task ProcessRequest(int requestId)
    {
        Console.WriteLine($"Request {requestId} is waiting to be processed.");

        await _semaphore.WaitAsync();

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