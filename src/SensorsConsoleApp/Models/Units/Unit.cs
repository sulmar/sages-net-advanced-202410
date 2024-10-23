namespace SensorsConsoleApp.Models.Units;

public abstract class Unit<T>
{
    public string Name { get; set; }
    public T Value { get; set; }
}
