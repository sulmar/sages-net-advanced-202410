using ActivatorExample;

Console.WriteLine("Hello, Reflection Activator!");

Customer customer = new Customer { Email = "john@domain.com " };

ICommand sendCommand = new SendCommand(customer, "Hello World!");
ICommand calculateCommand = new CalculateCommand(customer);

Queue<ICommand> commands = new Queue<ICommand>();
commands.Enqueue(sendCommand);
commands.Enqueue(sendCommand);
commands.Enqueue(sendCommand);
commands.Enqueue(calculateCommand);

while (commands.Count > 0)
{
    ICommand command = commands.Dequeue();

    command.Execute();
}

string[] messages = [
    "Hello World!",
    "Hello .NET",
    "Hello John"
    ];

foreach (string message in messages)
{
   // customer.Send(message);
}


BankAccount account = new BankAccount(1000); // Początkowy stan konta 1000
account.Deposit(100);
account.Withdraw(50);
account.Withdraw(200);



CommandInvoker invoker = new CommandInvoker(account);



// Wykonanie poleceń
invoker.ExecuteCommand("Deposit", 100); // Wpłata 100
invoker.ExecuteCommand("Withdraw", 50);  // Wypłata 50
invoker.ExecuteCommand("Withdraw", 200); // Wypłata 200
invoker.ExecuteCommand("NonExistent", 100); // To powinno zwrócić błąd