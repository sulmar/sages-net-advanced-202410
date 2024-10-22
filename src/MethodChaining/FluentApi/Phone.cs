namespace FluentApi;

public class Phone
{
    public void Call(string from, string to)
    {
        Console.WriteLine($"Calling from {from} to {to}");
    }

    public void Call(string from, string to, string subject)
    {
        Console.WriteLine($"Calling from {from} to {to} with subject {subject}");
    }

    public void Call(string from, IEnumerable<string> tos, string subject)
    {
        foreach (var to in tos)
        {
            Call(from, to, subject);
        }
    }
}

// Wzorzec Projektowy Budowniczny (Builder Design Pattern)
public class FluentPhone
{
    private string from;
    private ICollection<string> to = [];

    private FluentPhone()
    { 
    }

    public static FluentPhone Hangup()  // Metoda fabrykująca (Fabric Method Design Pattern)
    {
        return new FluentPhone();
    }

    public FluentPhone From(string from)
    {
        this.from = from;

        return this;
    }

    public FluentPhone To(string to)
    {
        this.to.Add(to);

        return this;
    }

    public void Call()
    {
        Call(from, to);
    }

    private void Call(string from, string to)
    {
        Console.WriteLine($"Calling from {from} to {to}");
    }

    private void Call(string from, IEnumerable<string> tos)
    {
        foreach (var to in tos)
        {
            Call(from, to);
        }
    }
}
