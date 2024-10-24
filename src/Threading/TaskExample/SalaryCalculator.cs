using System.Threading;

namespace TaskExample;

public class SalaryCalculator
{
    // Metoda asynchroniczna
    public Task<decimal> CalculateGrossSalaryAsync(decimal hourlyRate, int hoursWorked, CancellationToken cancellationToken = default, IProgress<string> progress = null)
    {
        return Task.Run(() => CalculateGrossSalary(hourlyRate, hoursWorked, cancellationToken, progress));
    }

    // Metoda asynchroniczna
    public Task<decimal> CalculateTaxAsync(decimal grossSalary, CancellationToken cancellationToken = default, IProgress<string> progress = null)
    {
        return Task.Run(() => CalculateTax(grossSalary, cancellationToken, progress));
    }

    // Metoda synchroniczna
    public decimal CalculateGrossSalary(decimal hourlyRate, int hoursWorked, CancellationToken cancellationToken = default, IProgress<string> progress = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        progress?.Report("Calculating gross salary...");
        Task.Delay(1000, cancellationToken).Wait();  // Simulating delay
        decimal grossSalary = hourlyRate * hoursWorked;
        progress?.Report($"Gross salary: {grossSalary:C}");
        return grossSalary;
    }

    

    // Metoda synchroniczna
    public decimal CalculateTax(decimal grossSalary, CancellationToken cancellationToken = default, IProgress<string> progress = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        progress?.Report("Calculating tax...");
        Task.Delay(2500, cancellationToken).Wait();  // Simulating delay
        decimal taxRate = 0.2m;  // 20% tax
        decimal tax = grossSalary * taxRate;
        progress?.Report($"Tax: {tax:C}");
        return tax;
    }
}
