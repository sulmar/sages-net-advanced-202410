using SensorsConsoleApp;

Console.WriteLine("Hello, Excercise 1!");

var sensors = new List<Sensor>
{
    new TemperatureSensor { Name = "Room 1" },
    new TemperatureSensor { Name = "Room 2" },

    new HumiditySensor { Name = "Room 1" },
    new MotionSensor { Name = "Room 2"}
};

while (true)
{
    foreach (var sensor in sensors)
    {
        sensor.UpdateValue();

        Console.WriteLine(sensor);
    }

    Thread.Sleep(1000);
}

