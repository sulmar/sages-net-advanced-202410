

```cs
  // Klasa czujnika temperatury
    public class TemperatureSensor
    {        
        AirConditioner ac = new AirConditioner();
 
        // Metoda symulująca odczyt z czujnika
        public void ReadTemperature(double temperature)
        {
            Console.WriteLine($"Odczytana temperatura: {temperature}°C");

            if (temperature > 25)
            {
                ac.TurnOn();
            }
            else
            {
                ac.TurnOff();
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
```