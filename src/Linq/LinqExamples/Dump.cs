namespace LinqExamples;

public static class EnumerableExtensions
{
    public static void Dump(this IEnumerable<Product> products, string message)
    {
        Console.WriteLine(message);

        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }
}
