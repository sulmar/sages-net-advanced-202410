﻿using System.Security.Cryptography;

namespace DependencyInjectionExample;

// TODO: Pokaż różnice Singleton, Scoped, Transient

public interface ICustomerRepository
{
    void Add();
}

public class DbCustomerRepository : ICustomerRepository
{
    private DbContext context;


    public DbCustomerRepository(DbContext context)
    {
        this.context = context;

        Console.WriteLine("DbCustomerRepository Activated.");
    }

    public void Add()
    {
        
    }
}

public class DbContext
{

}

public class CustomersViewModel
{
    private ICustomerRepository customerRepository;
    private IMessageService messageService;
    
    public CustomersViewModel(ICustomerRepository customerRepository, IMessageService messageService)
    {        
        this.customerRepository = customerRepository;
        this.messageService = messageService;
    }
    
    public string Message { get; set; }

    public void Add()
    {
        customerRepository.Add();
        messageService.Send(Message);
    }

    public void Update()
    {
        messageService.Send(Message);
    }
}

public class CustomersController
{
    private ICustomerRepository customerRepository;
    private IMessageService messageService;

    public CustomersController(ICustomerRepository customerRepository, IMessageService messageService)
    {
        this.customerRepository = customerRepository;
        this.messageService = messageService;
    }

    public void Post(string message)
    {
        customerRepository.Add();
        messageService.Send(message);
    }

    public void Put(string message)
    {
        messageService.Send(message);
    }
}

public interface IMessageService
{
    void Send(string message);
}

public class EmailMessageService : IMessageService
{
    public EmailMessageService()
    {
        Console.WriteLine("EmailMessageService Activated.");
    }
    public void Send(string message)
    {
        Console.WriteLine($"Sending {message} by email...");
    }
}

public class SmsMessageService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending {message} by sms...");
    }
}