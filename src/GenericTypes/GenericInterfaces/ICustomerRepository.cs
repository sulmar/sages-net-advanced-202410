using System.Diagnostics.SymbolStore;
using System.Security.Principal;

namespace GenericTypes;

public class Corporation : Customer
{
    public string MarketIndex { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()} MarketIndex: {MarketIndex}";
    }
}

public abstract class Base
{
   
}

public abstract class BaseEntity : Base
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}

public class Employee : Base
{

}

public class Customer : BaseEntity
{
    public required string Name { get; set; }
    public int EstYear { get; set; }

    public override string ToString()
    {
        return $"Id: {this.Id} Name: {this.Name}";
    }
}

public class User : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
}

public class Account : BaseEntity
{
    public string Number { get; set; }
}

// Szablon - interfejs ugólniony (generyczny)
public interface IEntityRepository<TEntity>     // TEntity - typ encji
    where TEntity : BaseEntity                 // reguła (constraint)
{
    IEnumerable<TEntity> GetAll();
    TEntity Get(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}

public interface ICustomerRepository : IEntityRepository<Customer>
{
   
}

public interface IUserRepository : IEntityRepository<User>
{
    IEnumerable<User> GetByEmail(string email);
}

public interface IAccountRepository : IEntityRepository<Account>
{

}
