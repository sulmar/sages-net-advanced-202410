using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AttributeBasedProgramming;

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


