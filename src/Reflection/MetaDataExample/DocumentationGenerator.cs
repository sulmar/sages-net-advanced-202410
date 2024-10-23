using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MetaDataExample;

public class DocumentationBuilder
{
    private StringBuilder builder = new StringBuilder();

    public void GenerateHeader(Type type)
    {
        builder.AppendLine($"{type.Namespace}, {type.Name}");
    }

    public void GenerateProperties(Type type)
    {
        builder.AppendLine("Właściwości: ");
        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            builder.AppendLine($"{property.Name} {property.PropertyType}");
        }
    }

    public void GenerateMethods(Type type)
    {
        builder.AppendLine("Metody: ");
        MethodInfo[] methods = type.GetMethods();

        foreach (MethodInfo method in methods)
        {
            builder.AppendLine($"{method.Name} {method.ReturnType}");
        }
    }

    public void GenerateEvents(Type type)
    {
        builder.AppendLine("Zdarzenia: ");
        EventInfo[] events = type.GetEvents();

        foreach (EventInfo @event in events)
        {
            builder.AppendLine($"{@event.Name} {@event.EventHandlerType.Name}");
        }
    }

    public void GenerateConstructors(Type type)
    {
        builder.AppendLine("Konstruktory: ");
        ConstructorInfo[] constructors = type.GetConstructors();

        foreach (ConstructorInfo constructor in constructors)
        {
            builder.AppendLine($"{constructor.Name}");
        }
    }

    public string Build()
    {
        return builder.ToString();
    }


}
