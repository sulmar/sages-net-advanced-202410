namespace EnumeratorExample;


public interface ISensor
{
    IEnumerable<float> GetValues();
}

public class TemperatureSensor : ISensor
{
    public IEnumerable<float> GetValues()
    {
        Random random = new Random();

        while (true)
        {
            // TODO: odczytaj wartość temperatury z czujnika
            float temperature = random.NextSingle() * 100;

            yield return temperature;
        }
    }
}
