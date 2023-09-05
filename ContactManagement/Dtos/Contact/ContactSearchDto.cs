namespace ContactManagement.Dtos;

public class ContactSearchDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
}