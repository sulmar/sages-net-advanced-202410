// See https://aka.ms/new-console-template for more information
using HashSetExample;
using Collections.Core;

Console.WriteLine("Hello, HashSet!");

TrackingServiceTest();

static void TrackingServiceTest()
{
    TrackingService trackingService = new TrackingService();

    string[] localIpAddresses =
    {
        "192.168.0.1",
        "10.0.0.1",
        "192.168.0.1",
        "192.168.0.2",
        "10.0.0.1",
        "192.168.0.3"
    };

    string[] remoteIpAddresses =
    {
        "192.168.0.1",
        "192.168.0.1",
        "192.168.0.2",
        "80.10.10.3"
    };

    HashSet<string> local = new HashSet<string>(localIpAddresses);
    HashSet<string> remote = new HashSet<string>(remoteIpAddresses);

    IEnumerable<string> ipAddresses = local.Union(remote); // suma zbiorów

    var query = remoteIpAddresses.Except(localIpAddresses).ToList(); // różnica zbiorów

    var localAndRemote = local.Intersect(remote).ToList();


    foreach (string ipAddress in ipAddresses)
    {
        trackingService.TrackIP(ipAddress);
    }

    var uniqueIPs = trackingService.GetUniqueIPs();

    uniqueIPs.Dump("List of Unique IP Addresses:");
}

