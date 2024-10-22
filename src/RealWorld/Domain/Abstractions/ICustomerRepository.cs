using Domain.Models;

namespace Domain.Abstractions;

public interface ICustomerRepository
{
    IEnumerable<Customer> GetAll();
}
