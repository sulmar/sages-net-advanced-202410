namespace GenericClassses;

#region Models

public abstract class Base
{
  
}

public abstract class BaseEntity : Base
{
    public int Id { get; set; }
}

public class Customer : BaseEntity
{
   
    public required string Name { get; set; }

    public override string ToString()
    {
        return $"CustomerId: {Id} Name: {Name}";
    }
}

public class Account : BaseEntity
{
    public required string Number { get; set; }
    public decimal Balance { get; set; }
    public override string ToString()
    {
        return $"AccountId: {Id} Number: {Number} Balance: {Balance}";
    }
}

#endregion

// Szablon - interfejs ugólniony (generyczny)
public interface IEntityRepository<TEntity>     // TEntity - typ encji
    where TEntity : BaseEntity                 // reguła (constraint)
{
    IEnumerable<TEntity> GetAll();
    TEntity Get(int id);
    void Add(TEntity entity);
}

public class InMemoryCustomerRepository
{
    private readonly IDictionary<int, Customer> _customers;

    public InMemoryCustomerRepository(IEnumerable<Customer> customers)
    {
        _customers = customers.ToDictionary(p => p.Id);
    }

    public void Add(Customer customer)
    {
        var id = _customers.Max(p => p.Key);

        customer.Id = ++id;

        _customers.Add(customer.Id, customer);
    }

    public Customer Get(int id)
    {
        return _customers[id];
    }

    public IEnumerable<Customer> GetAll()
    {
        return _customers.Values;
    }
}


public class InMemoryAccountRepository : InMemoryEntityRepository<Account>, IAccountRepository
{
    public InMemoryAccountRepository(IEnumerable<Account> entities) : base(entities)
    {
    }
}

public interface IAccountRepository : IEntityRepository<Account>
{

}

// Szablon klasy (klasa generyczna)
public class InMemoryEntityRepository<TEntity> : IEntityRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly IDictionary<int, TEntity> _entities;

    public InMemoryEntityRepository(IEnumerable<TEntity> entities)
    {
        _entities = entities.ToDictionary(p => p.Id);
    }

    public virtual void Add(TEntity entity)
    {
        var id = _entities.Max(p => p.Key);

        entity.Id = ++id;

        _entities.Add(entity.Id, entity);
    }

    public virtual TEntity Get(int id)
    {
        return _entities[id];
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return _entities.Values;
    }
}
