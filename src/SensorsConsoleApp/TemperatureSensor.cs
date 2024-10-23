namespace SensorsConsoleApp;

public abstract class Sensor
{
    public string Name { get; set; }
    public DateTime? LastUpdated { get; set; }
    public virtual void UpdateValue()
    {
        LastUpdated = DateTime.UtcNow;
    }
}

public abstract class Unit<T>
{
    public string Name { get; set; }
    public T Value { get; set; }
}

public class Temperature : Unit<double>
{

}

public class Humidity : Unit<int>
{

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

public class TemperatureSensor : Sensor<Temperature>
{
    public override void UpdateValue()
    {
         Value = new Temperature { Value = random.NextDouble() * 100, Name = "Celsius" };

        base.UpdateValue();
    }  
}

public class HumiditySensor : Sensor<Humidity>
{
    public override void UpdateValue()
    {
        Value = new Humidity { Value = random.Next(1, 100), Name = "%" };

        base.UpdateValue();
    }
}

public class MotionSensor : Sensor<bool>
{
    public override void UpdateValue()
    {
        Value = random.Next(1, 100) % 2 == 0;

        base.UpdateValue();
    }
}
