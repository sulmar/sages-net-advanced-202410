using GenericMethods;

Console.WriteLine("Hello, Generic Methods!");


// Przykład użycia z listą liczb całkowitych
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
Console.WriteLine("Zawartość listy liczb całkowitych:");
ListHelper.Dump(numbers);

// Przykład użycia z listą napisów
List<string> words = new List<string> { "C#", "Java", "Python", "JavaScript" };
Console.WriteLine("\nZawartość listy napisów:");
ListHelper.Dump<string>(words);


List<Customer> customers = new List<Customer> {
    new Customer { Id = 1, Name = "Microsoft" },
    new Customer { Id = 2, Name = "Google" },
    new Customer { Id = 3, Name = "Apple" }
};

Console.WriteLine("\nZawartość listy klientów:");

ListHelper.Dump<Customer>(customers);


