using System.Net.Http.Headers;
using TaskExample;

Console.WriteLine("Hello, Tasks!");

EmailMessageService messageService = new EmailMessageService();

Task.Run(()=> messageService.SendTo("john@domain.com"))
    .ContinueWith(t => messageService.SendTo("kate@domain.com"));

Console.WriteLine("Press any to exit.");
Console.ReadKey();



void SendTest()
{
    EmailMessageService messageService = new EmailMessageService();
  

    "Started.".DumpThreadId();

    IEnumerable<Task> tasks = Enumerable.Range(1, 100).Select(_ => new Task(() => messageService.SendToMe()));

    foreach (Task task in tasks)
    {
        task.Start();
    }

    "Done.".DumpThreadId();

}

// TaskWithResultTest();

static void TaskWithResultTest()
{
    Console.WriteLine("Starting payroll calculation...");

    decimal hourlyRate = 50m;
    int hoursWorked = 160;

    SalaryCalculator calculator = new SalaryCalculator();

    decimal grossSalary = calculator.CalculateGrossSalary(hourlyRate, hoursWorked);

    decimal tax = calculator.CalculateTax(grossSalary);

    Console.WriteLine($"Tax: {tax:C}");
}
