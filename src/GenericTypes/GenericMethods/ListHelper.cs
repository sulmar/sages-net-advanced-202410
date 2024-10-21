using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethods;

internal class ListHelper
{
    // Szablon metody (Metoda generyczna)
    public static void Dump<T>(IEnumerable<T> collection)
    {
        foreach (T item in collection)
        {
            Console.WriteLine(item.ToString());
        }
    }

    // string output = "a" + "b" + "c"

    public static string DumpToString<T>(IEnumerable<T> elements, string message = "")
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (var element in elements)
        {
            stringBuilder.AppendLine(element.ToString());
        }

        return stringBuilder.ToString();
    }

}
