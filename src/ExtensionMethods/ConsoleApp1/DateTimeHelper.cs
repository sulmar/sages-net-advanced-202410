namespace ConsoleApp1;

public static class DateTimeHelper
{    
    public static bool IsHoliday(DateTime date)
    {
        return DateTime.Today.DayOfWeek == DayOfWeek.Saturday || DateTime.Today.DayOfWeek == DayOfWeek.Sunday;
    }
}


public static class DateTimeExtensions
{
    public static bool IsHoliday(this DateTime date)
    {
        return DateTime.Today.DayOfWeek == DayOfWeek.Saturday || DateTime.Today.DayOfWeek == DayOfWeek.Sunday;
    }
}

public static class IntExtensions
{
    public static string ToBoldMarkdown(this int value, string separator = "**")
    {
        return $"{separator}{value}{separator}";
    }
}