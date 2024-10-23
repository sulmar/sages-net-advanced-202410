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

        DocumentationGenerator generator = new DocumentationGenerator();

        generator.GenerateHeader(type);
        generator.GenerateProperties(type);
        generator.GenerateProperties(type);
        generator.GenerateEvents(type);
        generator.GenerateConstructors(type);

    }
}