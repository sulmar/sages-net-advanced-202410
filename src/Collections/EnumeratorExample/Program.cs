
using EnumeratorExample;
using System.Collections.ObjectModel;

Console.WriteLine("Hello, Enumerator!");

CircualList<int> cicrualList = new CircualList<int>();
cicrualList.Add(1);
cicrualList.Add(2);
cicrualList.Add(3);
cicrualList.Add(4);
cicrualList.Add(5);

foreach (int item in cicrualList)
{
    Console.WriteLine(item);
    Thread.Sleep(1000);
}



ISensor sensor = new TemperatureSensor();

foreach (var temperature in sensor.GetValues())
{
    Console.WriteLine(temperature);

    if (temperature > 90)
    {
        break;
    }

    Thread.Sleep(1000);
}

return;

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

