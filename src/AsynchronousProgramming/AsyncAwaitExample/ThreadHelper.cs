namespace AsyncAwaitExample;

public static class ThreadHelper
{
    public static void DumpThreadId(this string message)
    {
        Console.WriteLine($"Thread ID = {Thread.CurrentThread.ManagedThreadId} : {message}");
    }
}
