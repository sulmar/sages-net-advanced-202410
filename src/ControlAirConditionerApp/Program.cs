using ControlAirConditionerApp;

Console.WriteLine("Hello, World!");

TemperatureSensor temperatureSensor = new TemperatureSensor();
temperatureSensor.HighTemperature += OnHighTemperature;
temperatureSensor.HighTemperature += (sender, args) =>
{
    Fan fan = new Fan();
    fan.TurnOff();
};

temperatureSensor.LowTemperature += OnLowTemperature;
temperatureSensor.LowTemperature += (sender, args) =>
{
    Fan fan1 = new Fan();
    fan1.TurnOn();
};



temperatureSensor.LowTemperature += (sender, args) => Console.Write("Nagrzewnica");

while (true)
{
    Console.Write("Podaj temperaturę: ");
    double temperature = double.Parse(Console.ReadLine());

    temperatureSensor.ReadTemperature(temperature);

}


static void OnHighTemperature(object sender, TemperatureEventArgs args)
{    
    AirConditioner ac = new AirConditioner();    

    ac.TurnOn();
}

static void OnLowTemperature(object sender, TemperatureEventArgs args)
{
    AirConditioner ac = new AirConditioner();

    ac.TurnOff();
}
