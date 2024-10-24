# Sterowanie klimatyzatorem

## Opis
Tworzymy rozwiązanie _ControlAirConditioner_ do monitorowania temperatury w pomieszczeniu, które automatycznie włącza klimatyzator, gdy temperatura przekroczy zadany poziom.

Obecna implementacja wygląda następująco:

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
   
```

## Zadanie
Dodaj sterowanie wentylatorem, który powinien zostać **wyłączony** gdy temperatura przekroczy zadany poziom. 
W przyszłości mogą pojawić się pojawić kolejne elementy wykonawcze.


