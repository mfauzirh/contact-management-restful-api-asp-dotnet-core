namespace ContactManagement.Dtos;

public class AddressResponseDto
{
    public int Id { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string Country { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
}