using System.Reflection;

namespace GetSetExample;

public class Customer
{    
    public string Name { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"Name = {Name}, Email = {Email}";
    }

    public void DoWork()
    {
        throw new NotImplementedException();
        Console.WriteLine(Name);
    }

    // Własny indekser
    public object this[string propertyName]
    {
        get
        {
            Type type = this.GetType();

            PropertyInfo property = type.GetProperty(propertyName);

            object value = property.GetValue(this);

            return value;
        }

        set
        {
            Type type = this.GetType();

            PropertyInfo property = type.GetProperty(propertyName);

            property.SetValue(this, value);
        }
    }

    public object this[int index]
    {
        get
        {
            Type type = this.GetType();

            PropertyInfo[] properties = type.GetProperties();

            PropertyInfo property =  properties[index];

            object value = property.GetValue(this);

            return value;
        }

        set
        {
            Type type = this.GetType();

            PropertyInfo[] properties = type.GetProperties();

            PropertyInfo property = properties[index];

            property.SetValue(this, value);
        }
    }

}
