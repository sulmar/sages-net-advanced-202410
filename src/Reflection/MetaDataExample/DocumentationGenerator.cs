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
    private Type type;

    public DocumentationBuilder WithType(Type type)
    {
        this.type = type;

        return this;
    }

    public DocumentationBuilder GenerateHeader()
    {
        builder.AppendLine($"{type.Namespace}, {type.Name}");

        return this;
    }

    public DocumentationBuilder GenerateProperties(string message)
    {
        builder.AppendLine(message);
        PropertyInfo[] properties = type.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            builder.AppendLine($"{property.Name} {property.PropertyType}");
        }


        return this;
    }

    public DocumentationBuilder GenerateMethods(string message)
    {
        builder.AppendLine(message);
        MethodInfo[] methods = type.GetMethods();

        foreach (MethodInfo method in methods)
        {
            builder.AppendLine($"{method.Name} {method.ReturnType}");
        }

        return this;
    }

    public DocumentationBuilder GenerateEvents(string message)
    {
        builder.AppendLine(message);
        EventInfo[] events = type.GetEvents();

        foreach (EventInfo @event in events)
        {
            builder.AppendLine($"{@event.Name} {@event.EventHandlerType.Name}");
        }

        return this;
    }

    public DocumentationBuilder GenerateConstructors()
    {
        builder.AppendLine("Konstruktory: ");
        ConstructorInfo[] constructors = type.GetConstructors();

        foreach (ConstructorInfo constructor in constructors)
        {
            builder.AppendLine($"{constructor.Name}");
        }

        return this;
    }

    public string Build()
    {
        return builder.ToString();
    }


}
