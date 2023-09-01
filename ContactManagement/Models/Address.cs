namespace ContactManagement.Models;

public class Address
{
    public int Id { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string Country { get; set; } = null!;
    public string PostalCode { get; set; } = null!;

    public int ContactId { get; set; }
    public Contact Contact { get; set; } = null!;
}