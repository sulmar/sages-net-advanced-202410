
using System.Collections.Concurrent;

Console.WriteLine("Hello, BlockingCollection!");


BlockingCollection<int> items = new BlockingCollection<int>();

Task task1  = Task.Run(()=> Producent(items));
Task task2 = Task.Run(() => Producent(items));

Task task3 = Task.Run(()=> Consumer(items));
Task task4 = Task.Run(() => Consumer(items));

Task.WaitAll(task3, task4);

static void Producent(BlockingCollection<int> items)
{
    for(int i = 0; i < 10; i++)
    {
        items.Add(i);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(i);
        Console.ResetColor();
    }
}

static void Consumer(BlockingCollection<int> items)
{
    foreach(int i in items.GetConsumingEnumerable())
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(i);
        Thread.Sleep(2000);
        Console.ResetColor();
    }
}
