namespace SetOperations;

public class Invoice
{
    public int Id { get; set; }
    public bool Paid { get; set; }
    public bool Posted { get; set; }
    
    public override string ToString()
    {
        return $"Invoice {Id} - Paid: {Paid}, Posted: {Posted}";
    }
}