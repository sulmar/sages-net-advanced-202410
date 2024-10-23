using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Markup;

namespace AttributeBasedProgramming;

public class Base : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;


    // Przykład atrybutu na poziomie parametru metody
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        Console.WriteLine(propertyName);
    }
}

[Description("Klient")]
[Icon("customer.ico")]
public class Customer : Base
{
    [Required, MinLength(3, ErrorMessage = "Imię zbyt krótkie")]
    [DisplayName("Imię")]
    public string FirstName { get; set; }

    [DisplayName("Nazwisko")]
    public string LastName { get; set; }

    private string? pesel;

    [IsReadOnly]
    public DateTime Birthday { get; set; }

    [Required]
    public string Pesel
    {
        get
        {
            return pesel;
        }
        set
        {
            pesel = value;

            OnPropertyChanged();
        }
    }

    public Gender Gender { get; set; }

    [Time]
    public void DoWork()
    {
        // Stopwatch stopwatch = Stopwatch.StartNew();

        // Simulate
        Thread.Sleep(1000);

        // stopwatch.Stop();

        // Console.WriteLine(stopwatch.Elapsed);

    }
}


public enum Gender
{
    [Description("Mezczyzna")]
    Male,

    [Description("Kobieta")]
    Female
}


