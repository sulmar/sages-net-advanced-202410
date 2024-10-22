using LinqExamples;

Console.WriteLine("Hello, Linq!");

string[] categories = ["Computer", "Books", "Food"];

ProductFaker faker = new ProductFaker(categories);

var allProducts = faker.Generate(100);

allProducts.Dump("All products");

// SQL: SELECT * FROM dbo.products WHERE color = 'red'

string? selectedColor = "red";

List<Product> filteredProducts = allProducts
    .Where(product => product.Color == selectedColor)
    .ToList();

filteredProducts.Dump("Filtered products");

var sortedFilteredProducts = allProducts
    .Where(product => product.Color == selectedColor)
    .OrderBy(product => product.Price)
    .ToList();

sortedFilteredProducts.Dump("Sorted filtered products by price");

// TODO: How many products is catalog by color?

var count = allProducts
    .Where(product => product.Color == selectedColor)
    .Count();

Console.WriteLine(count);

// SQL: SELECT Name, Price FROM dbo.products WHERE color = 'red'

var query = allProducts
    .Select(product => new { product.Name, product.Price })
    .ToList();

foreach (var product in query)
{
    Console.WriteLine($"Name: {product.Name} Price: {product.Price}");
}

// TODO: How many products is catalog by Category?

// SQL: SELECT Category, COUNT(*) FROM Products GROUP BY Category

var groupedProducts = allProducts
    .GroupBy(product => product.Category)
    .Select( group => new { Category = group.Key, Count = group.Count() })
    .ToList();


List<Product> filteredByColorAndPriceProducts = allProducts
    .Where(product => product.Color == selectedColor || product.IsDiscounted)
    .Where(product => product.Price > 100)
    .ToList();


IQueryable<Product> query2 = allProducts.AsQueryable();

decimal? selectedPrice = 100;

if (selectedColor != null)
    query2 = query2.Where(product => product.Color == selectedColor);

if (selectedPrice.HasValue)
    query2 = query2.Where(product => product.Price > selectedPrice);

var results = query2.ToList();


Console.WriteLine();
Console.ReadLine();

