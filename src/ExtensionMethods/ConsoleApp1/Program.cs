using ConsoleApp1;

Console.WriteLine("Hello, Extension Methods!");


if (DateTime.Today.IsHoliday())
{
    Console.WriteLine("Już weekend!");
}
else
{
    Console.WriteLine("Dzień roboczy.");
}


int x = 10;

Console.WriteLine(x.ToBoldMarkdown("##"));


