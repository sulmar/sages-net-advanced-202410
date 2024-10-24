namespace ControlAirConditionerApp;

public class TemperatureEventArgs : EventArgs
{
    public double Temperature { get; }

    public TemperatureEventArgs(double temperature)
    {
        Temperature = temperature;
    }
}

// Klasa czujnika temperatury
public class TemperatureSensor
{
    public event EventHandler<TemperatureEventArgs> HighTemperature;
    public event EventHandler<TemperatureEventArgs> LowTemperature;

    public const double LimitTemperature = 25;

    public readonly DateTime StartedDate;

    public TemperatureSensor()
    {
        StartedDate = DateTime.Now;
    }

    // Metoda symulująca odczyt z czujnika
    public void ReadTemperature(double temperature)
    {
        Console.WriteLine($"Odczytana temperatura: {temperature}°C");

        if (temperature > LimitTemperature)       
        {
            HighTemperature?.Invoke(this, new TemperatureEventArgs(temperature));         
        }
        else
        {
            LowTemperature?.Invoke(this, new TemperatureEventArgs(temperature));
        }
    }
}

// Klasa klimatyzacji
public class AirConditioner
{
    public void TurnOn()
    {
        Console.WriteLine("Klimatyzacja włączona.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Klimatyzacja wyłączona.");
    }
}

// Klasa wentylatora
public class Fan
{
    public void TurnOn()
    {
        Console.WriteLine("Wentylator włączony.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Wentylator wyłączony.");
    }
}


