using System.Reflection;

namespace Delegates;

public class LogOptions
{
    public bool File { get; set; }
    public bool Console { get; set; }
    public bool Db { get; set; }
}


// *f(int)

public class Printer
{

    // Zmienna, która przechowuje referencję do metod(y)
    public Action<string> Log;

    public Func<int, decimal> CalculateCost;

    public event EventHandler<PrintedEventArgs> Printed;

    public Predicate<string> CanPrint;

    public void Print(string content, byte copies = 1)
    {
        for (int copy = 0; copy < copies; copy++)
        {
            string message = $"{DateTime.Now} Printing {content} copy #{copy}";

            //if (Log != null)
            //    Log.Invoke(message);

            Log?.Invoke(message);
        }

        decimal? cost = CalculateCost?.Invoke(copies);

        if (cost.HasValue)
        {
            DisplayLCD(cost.Value);
        }

        // TODO: Send printed signal 
        Printed?.Invoke(this, new PrintedEventArgs(copies));        
    }



    

    private void DisplayLCD(decimal cost)
    {
        Console.WriteLine($"LCD: {cost}");
    }
}

public class PrintedEventArgs : EventArgs
{
    public int Copies { get; }

    public PrintedEventArgs(int copies)
    {
        Copies = copies;
    }
}