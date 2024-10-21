namespace ListExample;

internal class ShoppingCart
{
    private List<CartItem> _items = Enumerable.Empty<CartItem>().ToList();

    public void AddItem(CartItem item)
    {
        _items.Add(item);
    }

    public void RemoveItem(string productName)
    {
        CartItem cartItem = _items.FirstOrDefault(x => x.ProductName == productName);

        _items.Remove(cartItem);
    }

    public IEnumerable<CartItem> GetItems()
    {
        return _items;
    }

    public void Clear()
    {
        _items.Clear();
    }

    public decimal CalculateTotal()
    {
        return _items.Select(item => item.Price * item.Quantity).Sum();
    }
}

