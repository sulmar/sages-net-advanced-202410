using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Markup;

namespace AttributeBasedProgramming;

public class Controller<T>
{
    public T Model { get; set; }


}

public class CustomersController : Controller<Customer>
{    
    public void Post()
    {
        // this.Model.IsValid
        // TODO: save to db
    }
}

public class CustomerValidator
{
    public bool IsValid(Customer customer)
    {
        Type type = typeof(Customer);

        var typeAttributes = type.GetCustomAttributes();

        PropertyInfo[] properties = type.GetProperties();

        foreach (var property in properties)
        {
            var propertyAttributes = property.GetCustomAttributes();

            if (Attribute.IsDefined(property, typeof(RequiredAttribute)))
            {
                object value = property.GetValue(customer, null);

                if (value == null)
                {
                    return false;
                }
            }
        }

        return true;


    }
}

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
public class Customer : Base
{
    [Required, MinLength(3, ErrorMessage = "Imię zbyt krótkie")]
    [DisplayName("Imię")]
    public string FirstName { get; set; }

    [DisplayName("Nazwisko")]
    public string LastName { get; set; }

    private string pesel;

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

    public void DoWork()
    {
        throw new NotImplementedException();
    }
}


public enum Gender
{
    [Description("Mezczyzna")]
    Male,

    [Description("Kobieta")]
    Female
}


