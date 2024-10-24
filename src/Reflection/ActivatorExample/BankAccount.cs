﻿using System.Reflection;
using System.Windows.Input;

namespace ActivatorExample;

public class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount(decimal initialBalance)
    {
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            return true;
        }

        return false;
    }


}

public class CommandInvoker
{
    private readonly BankAccount _account;

    public CommandInvoker(BankAccount account)
    {
        _account = account;
    }

    public void ExecuteCommand(string commandName, decimal amount)
    {
        ICommand command = null;

        string classname = $"ActivatorExample.{commandName}Command";

        Type type = Assembly.GetExecutingAssembly().GetType(classname);

        if (type != null)
        {
            object[] args = { _account, amount };

            command = Activator.CreateInstance(type, args) as ICommand; // Utworzenie instancji obiektu (new "WithCommand")

            command?.Execute();

        }
        else
        {
            Console.WriteLine($"Command '{commandName}' not found.");
        }

    }
}

public interface ICommand
{
    void Execute();
}

// TODO: Dodaj atrybut [Command("Wplata")]
public class DepositCommand : ICommand
{
    private readonly BankAccount _account;
    private readonly decimal _amount;

    public DepositCommand(BankAccount account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        _account.Deposit(_amount);
        Console.WriteLine($"Deposited {_amount} to account. New balance: {_account.Balance}");
    }
}

public class WithdrawCommand : ICommand
{
    private readonly BankAccount _account;
    private readonly decimal _amount;

    public WithdrawCommand(BankAccount account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute()
    {
        if (_account.Withdraw(_amount))
        {
            Console.WriteLine($"Withdrew {_amount} from account. New balance: {_account.Balance}");
        }
        else
        {
            Console.WriteLine("Insufficient funds for withdrawal.");
        }
    }
}
