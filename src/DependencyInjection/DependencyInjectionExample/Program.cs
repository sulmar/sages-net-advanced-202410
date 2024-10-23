using DependencyInjectionExample;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, Dependency Injection!");

// dotnet add package Microsoft.Extensions.DependencyInjection

// Tworzymy kontener do wstrzykiwania zależności (Dependency Injection)

var serviceProvider = new ServiceCollection()
    .AddTransient<IMessageService, EmailMessageService>()
    .AddTransient<ICustomerRepository, DbCustomerRepository>()
    .AddTransient<DbContext>()
    .AddTransient<CustomersViewModel>()
    .AddTransient<CustomersController>()
    .BuildServiceProvider();

CustomersViewModel customersViewModel = serviceProvider.GetService<CustomersViewModel>();

CustomersController customersController = serviceProvider.GetService<CustomersController>();


customersViewModel.Add();
customersController.Post("a");