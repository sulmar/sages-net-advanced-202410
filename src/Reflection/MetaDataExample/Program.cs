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

        builder
            .WithType(type)
            .GenerateHeader()
            .GenerateProperties("Właściwości")
            .GenerateMethods("Metody")
            .GenerateEvents("Zdarzenia")
            .GenerateConstructors();

        Console.WriteLine(builder.Build());

    }
}