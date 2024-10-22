using LinqExamples;

Console.WriteLine("Hello, Linq!");

string[] categories = ["Computer", "Books", "Food"];

ProductFaker faker = new ProductFaker(categories);

var allProducts = faker.Generate(100);

allProducts.Dump("All products");

// TODO: Get products by color

string selectedColor = "red";

List<Product> filteredProducts = [];

foreach (Product product in allProducts)
{
    if (product.Color == selectedColor)
    {
        filteredProducts.Add(product);
    }
}

filteredProducts.Dump("Filtered products");



// TODO: Sort products by price

// TODO: How many products is catalog?

// TODO: How many products is catalog by Category?


