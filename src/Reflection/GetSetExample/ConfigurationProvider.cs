namespace GetSetExample;

public class ConfigurationProvider
{
    public Configuration Load()
    {
        Configuration configuration = new Configuration();

        Type configurationType = configuration.GetType();

        var properties = configurationType.GetProperties();

        // Load Configuration
        foreach (var propertyInfo in properties)
        {
            Console.WriteLine($"SQL: SELECT {propertyInfo.Name}  FROM Configurations");

            object configValueDb = "2024-10-23";

            object configValue = Convert.ChangeType(configValueDb, propertyInfo.PropertyType);

            propertyInfo.SetValue(configuration, configValue);


        }

        return configuration;
    }


    public void Save(Configuration configuration)
    {
        Type configurationType = configuration.GetType();

        var properties = configurationType.GetProperties();


        // Save Configuration
        foreach (var propertyInfo in properties)
        {
            object configValue = propertyInfo.GetValue(configuration);

            Console.WriteLine($"SQL: UPDATE Configurations SET {propertyInfo.Name} = {configValue}");
        }

    }
}
