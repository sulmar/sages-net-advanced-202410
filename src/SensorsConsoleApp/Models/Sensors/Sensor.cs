namespace SensorsConsoleApp.Models.Sensors;

public abstract class Sensor
{
    public string Name { get; set; }
    public DateTime? LastUpdated { get; set; }
    public virtual void UpdateValue()
    {
        LastUpdated = DateTime.UtcNow;
    }
}


public abstract class Sensor<TValue> : Sensor
{
    public TValue Value { get; set; }

    protected Random random = new Random();

    public override string ToString()
    {
        return $"Sensor: {Name}, Value: {Value}, Last Updated: {LastUpdated}";
    }
}