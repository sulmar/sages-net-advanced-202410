using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class DbCustomerRepository : ICustomerRepository
{
    public IEnumerable<Customer> GetAll()
    {
        throw new NotImplementedException();
    }
}
