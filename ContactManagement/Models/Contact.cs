namespace ContactManagement.Models;

public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public string UserName { get; set; } = null!;
    public User User { get; set; } = null!;

    public List<Address> Addresses { get; set; } = new List<Address>();

}