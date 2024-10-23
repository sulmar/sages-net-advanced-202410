using DependencyInjectionExample;

Console.WriteLine("Hello, Dependency Injection!");

// dotnet add package Microsoft.Extensions.DependencyInjection

CustomersViewModel customersViewModel = new CustomersViewModel(
                    new DbCustomerRepository(new DbContext()),
                            new SmsMessageService());


CustomersController customersController = new CustomersController(
                        new DbCustomerRepository(new DbContext()),
                            new SmsMessageService());


customersViewModel.Add();
customersController.Post("a");