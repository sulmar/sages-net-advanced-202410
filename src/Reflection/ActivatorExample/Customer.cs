namespace ActivatorExample;

public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
}


public class SendCommand : ICommand
{
    private Customer _customer;
    private string _message;

    public SendCommand(Customer customer, string message)
    {
        _customer = customer;
        _message = message;
    }

    public void Execute()
    {
        Send(_message);
    }

    private void Send(string message)
    {
        Console.WriteLine($"Send {message} to {_customer.Name} <{_customer.Email}>");
    }
}

public class CalculateCommand : ICommand
{
    private Customer _customer;

    public CalculateCommand(Customer customer)
    {
        _customer = customer;
    }

    public void Execute()
    {
        Calculate();
    }

    private void Calculate()
    {
        _customer.Salary = _customer.Email.Length * 100;
    }
}