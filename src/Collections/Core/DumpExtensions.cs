using System.Text;

namespace Collections.Core;

public static class DumpExtensions
{
    public static void Dump<T>(this IEnumerable<T> elements, string message = "")
    {
        Console.WriteLine(message);

        foreach (var element in elements)
        {
            Console.WriteLine(element);
        }
    }

    public static string DumpToString<T>(this IEnumerable<T> elements, string message = "")
    {     
        StringBuilder stringBuilder = new StringBuilder();

        foreach (var element in elements)
        {
            stringBuilder.AppendLine(element.ToString());
        }

        return stringBuilder.ToString();
    }
}
