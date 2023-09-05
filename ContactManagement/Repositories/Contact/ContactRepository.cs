using ContactManagement.Data;
using ContactManagement.Models;

namespace ContactManagement.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly DataContext _context;

    public ContactRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<Contact> AddAsync(Contact contact)
    {
        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();
        return contact;
    }
}