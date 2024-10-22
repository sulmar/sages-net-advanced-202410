namespace Delegates;

public class Printer
{
    public void Print(string content, byte copies = 1)
    {
        for (int copy = 0; copy < copies; copy++)
        {
            // TODO: Log to Console and/or to LogFile
            string message = $"{DateTime.Now} Printing {content} copy #{copy}";

            LogToConsole(message);
            LogToFile(message);
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

    private static void LogToFile(string message)
    {
        File.AppendAllText("log.txt", message);
    }

    private static void LogToConsole(string message)
    {
        Console.WriteLine(message);
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