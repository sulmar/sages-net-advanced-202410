namespace MonitorExample;

internal class ConfigManager
{
    private readonly Dictionary<string, object> settings = new Dictionary<string, object>();

    protected ConfigManager()
    {

    }

    private static readonly object lockObject = new object();

    private static ConfigManager instance;

    public static ConfigManager Instance
    {
        get
        {       // <---- t2

            Monitor.Enter(lockObject);

            try
            {

                if (instance == null) // <--- t1
                {
                    Thread.Sleep(200);

                    instance = new();
                }
            }

            finally
            {
                Monitor.Exit(lockObject);
            }


            return instance;
        }
    }

    public void Set(string key, object value)
    {       
        if (settings.ContainsKey(key))
        {
            settings[key] = value;
        }
        else
        {
            settings.Add(key, value);
        }
    }

    public object Get(string key)
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} getting {key}");

        if (settings.ContainsKey(key))
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} getting {settings[key]}");

            return settings[key];
        }
        else
            return null;

    }
}
