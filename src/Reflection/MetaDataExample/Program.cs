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

        DocumentationBuilder builder = new DocumentationBuilder();
        builder.GenerateHeader(type);
        builder.GenerateProperties(type);
        builder.GenerateProperties(type);
        builder.GenerateEvents(type);
        builder.GenerateConstructors(type);


        Console.WriteLine(builder.Build());

    }
}