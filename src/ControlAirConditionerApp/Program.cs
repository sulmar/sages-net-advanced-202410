using ControlAirConditionerApp;

Console.WriteLine("Hello, World!");

TemperatureSensor temperatureSensor = new TemperatureSensor();
temperatureSensor.HighTemperature += OnHighTemperature;
temperatureSensor.HighTemperature += (temperature) =>
{
    Fan fan = new Fan();
    fan.TurnOff();
};

temperatureSensor.LowTemperature += OnLowTemperature;
temperatureSensor.LowTemperature += (temperature) =>
{
    Fan fan = new Fan();
    fan.TurnOn();
};

while (true)
{
    Console.Write("Podaj temperaturę: ");
    double temperature = double.Parse(Console.ReadLine());

    temperatureSensor.ReadTemperature(temperature);

}


static void OnHighTemperature(double temperature)
{
    AirConditioner ac = new AirConditioner();    

    ac.TurnOn();
}

static void OnLowTemperature(double temperature)
{
    AirConditioner ac = new AirConditioner();

    ac.TurnOff();
}
