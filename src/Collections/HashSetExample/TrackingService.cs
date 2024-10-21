namespace HashSetExample;

internal class TrackingService
{
    private HashSet<string> uniqueIPs = new HashSet<string>();

    public void TrackIP(string ipAddress)
    {
       uniqueIPs.Add(ipAddress);
    }

    public IEnumerable<string> GetUniqueIPs()
    {        
        return uniqueIPs;
    }
}

