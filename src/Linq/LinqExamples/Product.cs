using Bogus;

namespace LinqExamples;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; }
    public bool IsDiscounted { get; set; }
    public string Category { get; set; }

    public override string ToString() => $"Id: {Id} Name: {Name} Price: {Price} Color: {Color} IsDiscounted: {IsDiscounted} Category: {Category}";
}


public class ProductFaker : Faker<Product>
{
    public ProductFaker(string[] categories)
    {
        UseSeed(1);
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.Name, f => f.Commerce.ProductName());
        RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()));
        RuleFor(p => p.Color, f => f.Commerce.Color());
        RuleFor(p => p.IsDiscounted, f => f.Random.Bool(0.2f));
        RuleFor(p => p.Category, f => f.PickRandom(categories));
    }
}

public interface IProductRepository
{
    IEnumerable<Product> GetProducts();
}

public class ProductRepository : IProductRepository
{
    private readonly IEnumerable<Product> _products;

    public ProductRepository(IEnumerable<Product> products)
    {
        _products = products;
    }

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }
}