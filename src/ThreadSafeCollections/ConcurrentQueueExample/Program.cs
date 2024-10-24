
using System.Collections.Concurrent;

Console.WriteLine("Hello, ConcurrentQueue!");

ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);

if (queue.TryDequeue(out int result) == false)
{

}

ConcurrentStack<int> stack = new ConcurrentStack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);

