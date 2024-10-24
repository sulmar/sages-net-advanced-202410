using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAirConditionerApp;

// Klasa czujnika temperatury
public class TemperatureSensor
{
    public delegate void LimitTemperatureDelegate(double temperature);
    
    public LimitTemperatureDelegate HighTemperature { get; set; }
    public LimitTemperatureDelegate LowTemperature { get; set; }

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

        if (temperature > LimitTemperature)       // Magic Number
        {
            HighTemperature?.Invoke(temperature);         
        }
        else
        {
            LowTemperature?.Invoke(temperature);
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


