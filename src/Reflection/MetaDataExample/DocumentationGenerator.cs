using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MetaDataExample;

public class DocumentationGenerator
{
    public void GenerateHeader(Type type)
    {
        Console.WriteLine($"{type.Namespace}, {type.Name}");
    }

    public void GenerateProperties(Type type)
    {
        Console.WriteLine("Właściwości: ");
        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine($"{property.Name} {property.PropertyType}");
        }
    }

    public void GenerateMethods(Type type)
    {
        Console.WriteLine("Metody: ");
        MethodInfo[] methods = type.GetMethods();

        foreach (MethodInfo method in methods)
        {
            Console.WriteLine($"{method.Name} {method.ReturnType}");
        }
    }

    public void GenerateEvents(Type type)
    {
        Console.WriteLine("Zdarzenia: ");
        EventInfo[] events = type.GetEvents();

        foreach (EventInfo @event in events)
        {
            Console.WriteLine($"{@event.Name} {@event.EventHandlerType.Name}");
        }
    }

    public void GenerateConstructors(Type type)
    {
        Console.WriteLine("Konstruktory: ");
        ConstructorInfo[] constructors = type.GetConstructors();

        foreach (ConstructorInfo constructor in constructors)
        {
            Console.WriteLine($"{constructor.Name}");
        }
    }


    }
