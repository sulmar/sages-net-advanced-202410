using GenericClassses;

Console.WriteLine("Hello, Generic Classes!");

var customers = new List<Customer>
{
    new Customer { Id = 1, Name = "Microsoft" },
    new Customer { Id = 2, Name = "Google" },
    new Customer { Id = 3, Name = "Apple" },
};

var accounts = new List<Account>
{
    new Account { Id = 1, Number = "11110000", Balance = 100},
    new Account { Id = 2, Number = "22220000", Balance = 200 },
    new Account { Id = 3, Number = "33330000", Balance = 300 },
    new Account { Id = 4, Number = "44440000", Balance = 400 },
    new Account { Id = 5, Number = "66660000", Balance = 500 },
};

InMemoryCustomerRepository repository = new InMemoryCustomerRepository(customers);

var customer = repository.Get(1);

Console.WriteLine(customer);