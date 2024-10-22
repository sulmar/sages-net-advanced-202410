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

    public void Print(string content, byte copies = 1)
    {
        for (int copy = 0; copy < copies; copy++)
        {
            // TODO: Log to Console and/or to LogFile
            string message = $"{DateTime.Now} Printing {content} copy #{copy}";

            //if (Log != null)
            //    Log.Invoke(message);

            Log?.Invoke(message);
        }

        // TODO: Calculate cost with 10% discount
        decimal? cost = CalculateCost(copies, 0.99M);

        if (cost.HasValue)
        {
            DisplayLCD(cost.Value);
        }

        // TODO: Send printed signal 
        Console.WriteLine($"Printed {copies} copies.");
    }



    private decimal CalculateCost(int copies, decimal cost)
    {
        return copies * cost;
    }

    private void DisplayLCD(decimal cost)
    {
        Console.WriteLine($"LCD: {cost}");
    }
}