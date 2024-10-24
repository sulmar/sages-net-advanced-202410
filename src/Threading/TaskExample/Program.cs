using System.Net.Http.Headers;
using TaskExample;

Console.WriteLine("Hello, Tasks!");

// SendContinueWithTest();
// VoteTest();

TaskWithResultTest();

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

static void SyncCalculatorTest()
{
    Console.WriteLine("Starting payroll calculation...");

    decimal hourlyRate = 50m;
    int hoursWorked = 160;

    SalaryCalculator calculator = new SalaryCalculator();

    decimal salary = calculator.CalculateGrossSalary(hourlyRate, hoursWorked);
    decimal tax = calculator.CalculateTax(salary);
    Console.WriteLine($"Tax: {tax:C}");

}

static void TaskWithResultTest()
{
    Console.WriteLine("Starting payroll calculation...");

    decimal hourlyRate = 50m;
    int hoursWorked = 160;

    SalaryCalculator calculator = new SalaryCalculator();

   Task.Run(()=> calculator.CalculateGrossSalary(hourlyRate, hoursWorked))
        .ContinueWith(t => Task.Run(() => calculator.CalculateTax(t.Result)))
            .ContinueWith(t => Console.WriteLine($"Tax: {t.Result:C}"));    
}



static void SendContinueWithTest()
{
    EmailMessageService messageService = new EmailMessageService();

    Task.Run(() => messageService.SendTo("john@domain.com"))
        .ContinueWith(t => messageService.SendTo("kate@domain.com"))
            .ContinueWith(t => messageService.SendTo("bob@domain.com"));
}

static void VoteTest()
{
    VoteService voteService = new VoteService();
    EmailMessageService emailMessageService = new EmailMessageService();

    IEnumerable<Task<bool>> tasks = Enumerable.Range(1, 10).Select(t => Task.Run(() => voteService.Get()));

    Task<bool> task1 = Task.Run(() => voteService.Get());

    // zła praktyka
    // Console.WriteLine(task1.Result);

    // dobra praktyka
    task1
        .ContinueWith(t => emailMessageService.SendTo($"vote@domain.com Result = {t.Result} "));

    //Task.WhenAll(tasks)
    //    .ContinueWith(tasks =>
    //    {
    //        foreach (var result in tasks.Result)
    //        {
    //            emailMessageService.SendTo($"vote@domain.com Result = {result} ");
    //        }
    //    });
}