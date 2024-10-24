using TaskExample;

Console.WriteLine("Hello, Tasks!");

// CancelationTokenSourceTest();


// SendContinueWithTest();
// VoteTest();

try
{
    TaskWithResultTest();
}
catch(OperationCanceledException e)
{
    Console.WriteLine("Operacja anulowana.");
}

// SecondTicker();


Console.WriteLine("Press Enter to exit.");
Console.ReadLine();


static void DoWork(CancellationToken token)
{
    while (true)
    {
        if (token.IsCancellationRequested)
        {
            break;
        }

        //if (token.IsCancellationRequested)
        //{
        //    throw new OperationCanceledException();
        //}

        // token.ThrowIfCancellationRequested();

        Console.Write(".");

        Thread.Sleep(1000);
    }
}

static async Task SecondTicker()
{
    int secs = 0;

    PeriodicTimer secondTimer = new PeriodicTimer(new TimeSpan(0, 0, 1));

    while (await secondTimer.WaitForNextTickAsync())
    {
        secs++;
        Console.SetCursorPosition(0, 2);
        Console.Write($"secs: {secs.ToString("00")}");
    }
}

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

static async void TaskWithResultTest()
{
    Console.WriteLine("Starting payroll calculation...");

    decimal hourlyRate = 50m;
    int hoursWorked = 160;

    CancellationTokenSource cts = new CancellationTokenSource();
    CancellationToken token = cts.Token;

    cts.CancelAfter(TimeSpan.FromSeconds(20));

    IProgress<string> consoleProgress = new DelegateProgress<string>(message => Console.WriteLine(message));

    // IProgress<string> consoleProgress = new ColorConsoleProgress();




    SalaryCalculator calculator = new SalaryCalculator();

    decimal salary = await calculator.CalculateGrossSalaryAsync(hourlyRate, hoursWorked, token, consoleProgress);
    decimal tax = await calculator.CalculateTaxAsync(salary, token, consoleProgress);
    Console.WriteLine($"Tax: {tax:C}");
}



static void SendContinueWithTest()
{
    EmailMessageService messageService = new EmailMessageService();

    Task.Run(() => messageService.SendTo("john@domain.com"))
        .ContinueWith(t => messageService.SendTo("kate@domain.com"))
            .ContinueWith(t => messageService.SendTo("bob@domain.com"));
}

static async void VoteTest()
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


    await Task.WhenAll(tasks);

    foreach (var result in tasks)
    {
        emailMessageService.SendTo($"vote@domain.com Result = {result} ");
    }

    //Task.WhenAll(tasks)
    //    .ContinueWith(tasks =>
    //    {
    //        foreach (var result in tasks.Result)
    //        {
    //            emailMessageService.SendTo($"vote@domain.com Result = {result} ");
    //        }
    //    });
}

static void CancelationTokenSourceTest()
{
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

    cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));

    CancellationToken token = cancellationTokenSource.Token;

    Task.Run(() => DoWork(token));

    Console.WriteLine("Press any to cancel.");
    Console.ReadKey();

    cancellationTokenSource.Cancel();
}