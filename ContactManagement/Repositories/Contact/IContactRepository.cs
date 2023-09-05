using ContactManagement.Models;

namespace ContactManagement.Repositories;

public interface IContactRepository
{
    Task<Contact> AddAsync(Contact contact);
    Task<Contact?> GetAsync(int contactId);
}