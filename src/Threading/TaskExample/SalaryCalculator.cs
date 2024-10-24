namespace TaskExample;

public class SalaryCalculator
{
    // Metoda asynchroniczna
    public Task<decimal> CalculateGrossSalaryAsync(decimal hourlyRate, int hoursWorked)
    {
        return Task.Run(() => CalculateGrossSalary(hourlyRate, hoursWorked));
    }

    // Metoda asynchroniczna
    public Task<decimal> CalculateTaxAsync(decimal grossSalary)
    {
        return Task.Run(() => CalculateTax(grossSalary));
    }

    // Metoda synchroniczna
    public decimal CalculateGrossSalary(decimal hourlyRate, int hoursWorked)
    {
        Console.WriteLine("Calculating gross salary...");
        Task.Delay(1000).Wait();  // Simulating delay
        decimal grossSalary = hourlyRate * hoursWorked;
        Console.WriteLine($"Gross salary: {grossSalary:C}");
        return grossSalary;
    }

    

    // Metoda synchroniczna
    public decimal CalculateTax(decimal grossSalary)
    {
        Console.WriteLine("Calculating tax...");
        Task.Delay(500).Wait();  // Simulating delay
        decimal taxRate = 0.2m;  // 20% tax
        decimal tax = grossSalary * taxRate;
        Console.WriteLine($"Tax: {tax:C}");
        return tax;
    }
}
