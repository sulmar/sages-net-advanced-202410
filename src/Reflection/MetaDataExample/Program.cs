using MetaDataExample;
using System;
using MetaDataExample.Models;
using System.Reflection;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, Reflection!");

        // Pobieramy typ jako obiekt
        Type type = typeof(Customer);

        Console.WriteLine($"{type.Namespace}, {type.Name}");

        Console.WriteLine("Właściwości: ");
        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine($"{property.Name} {property.PropertyType}");
        }

        Console.WriteLine("Metody: ");
        MethodInfo[] methods = type.GetMethods();

        foreach (MethodInfo method in methods)
        {
            Console.WriteLine($"{method.Name} {method.ReturnType}");
        }

        Console.WriteLine("Zdarzenia: ");
        EventInfo[] events = type.GetEvents();

        foreach (EventInfo @event in events)
        {
            Console.WriteLine($"{@event.Name} {@event.EventHandlerType.Name}");
        }


        Console.WriteLine("Konstruktory: ");
        ConstructorInfo[] constructors = type.GetConstructors();

        foreach(ConstructorInfo constructor in constructors)
        {
            Console.WriteLine($"{constructor.Name}");
        }
    }
}