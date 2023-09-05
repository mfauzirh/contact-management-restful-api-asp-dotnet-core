using ContactManagement.Models;

namespace ContactManagement.Repositories;

public interface IAddressRepository
{
    Task<Address> AddAsync(Address address);
    Task<Address?> GetAsync(int contactId, int addressId);
    Task<Address> UpdateAsync(Address address);
    Task<Address> DeleteAsync(Address address);
    Task<List<Address>> ListAsync(int contactId);
}