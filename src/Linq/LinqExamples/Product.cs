namespace LinqExamples;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; }
    public bool IsDiscounted { get; set; }
    public string Category { get; set; }
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