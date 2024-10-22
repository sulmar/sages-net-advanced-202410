
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

printer.PowerOff = () => Console.WriteLine("Drukarka została wyłączona");

if (options.Console)
    printer.Log += Console.WriteLine;

var logToFile = (string msg) => File.AppendAllText("log.txt", msg + Environment.NewLine);

logToFile("Hello Lambda");

if (options.File)
{
    // Metoda anonimowa zdefiniowana za pomocą wyrażenia lambda
    printer.Log += logToFile;

    printer.Log += _ => File.AppendAllText("log.txt", "Test drukarki" + Environment.NewLine);
}

if (options.Db)
    printer.Log += LogToDb;

printer.Print("Lorem ipsum", 5);


printer.Log -= LogToDb;
printer.Print("Hello World!", 3);

printer.Log = null;
printer.Print("Hello .NET!", 1);

static void LogToDb(string msg)
{
    Console.WriteLine($"save to db: {msg}");
}
static void OnPrinted(object sender, PrintedEventArgs args)
{
    Console.WriteLine($"Printed {args.Copies} copies.");
}