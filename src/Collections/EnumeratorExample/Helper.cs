using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorExample;

internal class Helper
{
    // Lazy Collection (leniwa kolekcja)
    public static IEnumerable<string> GetWeekDays()
    {
        yield return "Poniedziałek";
        yield return "Wtorek";
        yield return "Środa";
        yield return "Czwartek";
        yield return "Piątek";
        yield return "Sobota";
        yield return "Niedziela";
    }

    public static IEnumerable<int> Infinity()
    {
        while (true)
        {
            Thread.Sleep(1000);
            yield return 10;
        }
    }   
}

public interface ISensor
{
    IEnumerable<float> GetValues();
}
