
using EnumeratorExample;
using System.Collections.ObjectModel;

Console.WriteLine("Hello, Enumerator!");


IEnumerable<string> weekDays = Helper.GetWeekDays();

foreach (string weekDay in weekDays)
{
    Console.WriteLine(weekDay);

    if (weekDay == "Środa")
    {
        break;
    }
}

return;

ICollection<int> numbers = new Collection<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

foreach (int number in numbers)
{
    Console.WriteLine(number);
}


//for (int i = 0; i < numbers.Count; i++)
//{
//    Console.WriteLine(numbers[i]);
//}

