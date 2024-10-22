
using Delegates;

Console.WriteLine("Hello, Delegates!");

LogOptions options = new LogOptions()
{
    Console = true,
    File = true,
    Db = true,
};

Printer printer = new Printer();
PrintCalculator calculator = new PrintCalculator();

printer.Printed += OnPrinted;

printer.CalculateCost += (copies) => calculator.CalculateDiscountedCost(copies, 0.2m);

if (options.Console)
    printer.Log += Console.WriteLine;

if (options.File)
{
    // Metoda anonimowa
    printer.Log += delegate (string message)
    {
        File.AppendAllText("log.txt", message + Environment.NewLine);
    };
}

if (options.Db)
    printer.Log += LogToDb;

printer.Print("Lorem ipsum", 5);


printer.Log -= LogToDb;
printer.Print("Hello World!", 3);

printer.Log = null;
printer.Print("Hello .NET!", 1);

static void LogToDb(string message)
{
    Console.WriteLine($"save to db: {message}");
}
static void OnPrinted(object sender, PrintedEventArgs args)
{
    Console.WriteLine($"Printed {args.Copies} copies.");
}