namespace ContactManagement.Dtos;

public class ContactCreateDto
{
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}