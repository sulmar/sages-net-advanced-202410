namespace Domain.Models;

public class Customer : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Address HomeAddress { get; set; }
}
