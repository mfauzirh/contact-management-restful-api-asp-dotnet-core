namespace ContactManagement.Models;

public class User
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; } = null!;

    public List<Contact> Contact { get; set; } = new List<Contact>();
}