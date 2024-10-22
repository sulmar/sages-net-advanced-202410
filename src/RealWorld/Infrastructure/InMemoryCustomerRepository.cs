using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class InMemoryCustomerRepository : ICustomerRepository
{
    public IEnumerable<Customer> GetAll()
    {
        throw new NotImplementedException();
    }
}
