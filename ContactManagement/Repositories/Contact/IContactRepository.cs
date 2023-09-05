using ContactManagement.Dtos;
using ContactManagement.Models;

namespace ContactManagement.Repositories;

public interface IContactRepository
{
    Task<Contact> AddAsync(Contact contact);
    Task<Contact?> GetAsync(int contactId);
    Task<Contact> UpdateAsync(Contact contact);
    Task<Contact> DeleteAsync(Contact contact);
    Task<ContactSearchResultDto> SearchAsync(string userName, ContactSearchDto searchBy);
}