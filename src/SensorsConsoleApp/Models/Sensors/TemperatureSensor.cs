using SensorsConsoleApp.Models.Units;

namespace SensorsConsoleApp.Models.Sensors;

public class TemperatureSensor : Sensor<Temperature>
{
    public override void UpdateValue()
    {
        Value = new Temperature { Value = random.NextDouble() * 100, Name = "Celsius" };

        base.UpdateValue();
    }
}
