using AttributeBasedProgramming;
using System.ComponentModel;
using System.Reflection;

Console.WriteLine("Hello, Attribute!");

Customer model = new Customer();
model.FirstName = "John";
// model.Pesel = "1234";

CustomerValidator validator = new CustomerValidator();

validator.IsValid(model);

Type type = typeof(Customer);

// Odczyt własnego atrybutu na poziomie klasy
IconAttribute iconAttribute = (IconAttribute) Attribute.GetCustomAttribute(type, typeof(IconAttribute));
Console.WriteLine(iconAttribute.Filename);

PropertyInfo[] properties = type.GetProperties();

foreach (PropertyInfo property in properties)
{
    // Odczyt własnego atrybutu na poziomie właściwości
    if (Attribute.IsDefined(property, typeof(IsReadOnlyAttribute)))
    {
        Console.WriteLine($"Pole {property.Name} jest wymagane");
    }
}


// TODO: odczytaj atrybut na poziomie właściwości

// TODO: Odczytaj atrybut na poziomie typu

// TODO: Odczytaj atrybut na poziomie metod

// TODO: Odczytaj atrybut na poziomie właściwości
