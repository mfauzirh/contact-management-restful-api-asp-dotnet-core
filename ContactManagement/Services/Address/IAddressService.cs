using ContactManagement.Dtos;

namespace ContactManagement.Repositories;

public interface IAddressService
{
    Task<AddressResponseDto> AddAsync(int contactId, AddressCreateDto addressCreateDto);
    Task<AddressResponseDto?> GetAsync(int contactId, int addressId);
}