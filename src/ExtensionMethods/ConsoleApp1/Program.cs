using ConsoleApp1;

Console.WriteLine("Hello, Extension Methods!");


if (DateTimeHelper.IsHoliday(DateTime.Today))
{
    Console.WriteLine("Już weekend!");
}
else
{
    Console.WriteLine("Dzień roboczy.");
}