using GetSetExample;
using System.Reflection;

Console.WriteLine("Hello, Reflection!");

Customer customer = new Customer { Name = "John Doe", Email = "john.doe@example.com" };


// TODO:  Przypisz wartości do właściwości za pomocą indeksu
// customer["Name"] = "John Doe";
// customer["Email"] = "john.doe@example.com";

Console.Write("Poda nazwę właściwości (Name/Email): ");
string propertyName = Console.ReadLine();

Type type = customer.GetType();

Console.WriteLine($"{type.Namespace} {type.Name}");

PropertyInfo property = type.GetProperty(propertyName);

// Odczyt wartości
object value = property.GetValue(customer);

Console.WriteLine(value);

// Ustawienie wartości
property.SetValue(customer, "John Smith");

Console.WriteLine(customer);

customer[propertyName] = "Marcin";

Console.WriteLine(customer[propertyName]);

Console.WriteLine(customer);