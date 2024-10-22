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

    // Definicja nagłówka metody (tylko sygnatura metody)
    public delegate void LogDelegate(string message);

    // Zmienna, która przechowuje referencję do metod(y)
    public LogDelegate Log;

    public delegate decimal CalculateCostDelegate(int copies);
    public CalculateCostDelegate CalculateCost;

    public delegate void PrintedDelegate(object sender, PrintedEventArgs args);
    public event PrintedDelegate Printed;

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