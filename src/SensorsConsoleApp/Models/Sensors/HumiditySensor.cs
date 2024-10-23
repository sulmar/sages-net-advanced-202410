using SensorsConsoleApp.Models.Units;

namespace SensorsConsoleApp.Models.Sensors;

public class HumiditySensor : Sensor<Humidity>
{
    public override void UpdateValue()
    {
        Value = new Humidity { Value = random.Next(1, 100), Name = "%" };

        base.UpdateValue();
    }
}
