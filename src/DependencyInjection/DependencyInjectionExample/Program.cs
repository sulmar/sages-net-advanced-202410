﻿using DependencyInjectionExample;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, Dependency Injection!");

// dotnet add package Microsoft.Extensions.DependencyInjection

// Tworzymy kontener do wstrzykiwania zależności (Dependency Injection)

var serviceProvider = new ServiceCollection()    
    .AddSingleton<IMessageService, SmsMessageService>()
    .AddSingleton<IMessageService, EmailMessageService>()
    .AddTransient<ICustomerRepository, DbCustomerRepository>()
    .AddScoped<DbContext>()
    .AddTransient<CustomersViewModel>()
    .AddTransient<CustomersController>()
    .BuildServiceProvider();

CustomersViewModel customersViewModel = serviceProvider.GetService<CustomersViewModel>();

CustomersController customersController = serviceProvider.GetService<CustomersController>();


customersViewModel.Add();
customersController.Post("a");