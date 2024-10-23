namespace SensorsConsoleApp.Models.Sensors;

public class MotionSensor : Sensor<bool>
{
    public override void UpdateValue()
    {
        Value = random.Next(1, 100) % 2 == 0;

        base.UpdateValue();
    }
}
