Console.WriteLine("Hello, Extension Methods!");


if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday || DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
{
    Console.WriteLine("Już weekend!");
}
else
{
    Console.WriteLine("Dzień roboczy.");
}