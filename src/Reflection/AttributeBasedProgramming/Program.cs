using AttributeBasedProgramming;

Console.WriteLine("Hello, Attribute!");

Customer model = new Customer();
model.FirstName = "John";
// model.Pesel = "1234";

CustomerValidator validator = new CustomerValidator();

validator.IsValid(model);




// TODO: odczytaj atrybut na poziomie właściwości

// TODO: Odczytaj atrybut na poziomie typu

// TODO: Odczytaj atrybut na poziomie metod

// TODO: Odczytaj atrybut na poziomie właściwości
