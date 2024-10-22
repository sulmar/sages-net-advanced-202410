using LinqExamples;

Console.WriteLine("Hello, Linq!");

string[] categories = ["Computer", "Books", "Food"];

ProductFaker faker = new ProductFaker(categories);

var products = faker.Generate(100);

foreach (var product in products)
{
    Console.WriteLine(product);
}

// TODO: Get products by color

// TODO: Sort products by price

// TODO: How many products is catalog?

// TODO: How many products is catalog by Category?


