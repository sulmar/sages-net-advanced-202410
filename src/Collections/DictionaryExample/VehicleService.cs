namespace DictionaryExample;

internal class VehicleService
{
    private Dictionary<string, Vehicle> _vehicles = new Dictionary<string, Vehicle>();

    public void Add(Vehicle vehicle)
    {
        _vehicles.Add(vehicle.PlateNumber, vehicle);
    }

    public Vehicle GetByPlateNumber(string plateNumber)
    {
        return _vehicles[plateNumber];
    }
}
