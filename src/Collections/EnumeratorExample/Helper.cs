using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorExample;

internal class Helper
{
    public static IEnumerable<string> GetWeekDays()
    {
        return new List<string>
        {
            "Poniedziałek",
            "Wtorek",
            "Środa",
            "Czwartek",
            "Piątek",
            "Sobota",
            "Niedziela"
        };
    }
}
