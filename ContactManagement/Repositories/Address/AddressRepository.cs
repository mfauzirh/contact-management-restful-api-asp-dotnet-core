using ContactManagement.Data;
using ContactManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly DataContext _context;

    public AddressRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Address> AddAsync(Address address)
    {
        await _context.Addresses.AddAsync(address);
        await _context.SaveChangesAsync();
        return address;
    }

    public async Task<Address?> GetAsync(int contactId, int addressId)
    {
        return await _context.Addresses.FirstOrDefaultAsync(a => a.ContactId == contactId && a.Id == addressId);
    }
}