using ContactManagement.Dtos;

namespace ContactManagement.Repositories;

public interface IAddressService
{
    Task<AddressResponseDto> AddAsync(int contactId, AddressCreateDto addressCreateDto);
    Task<AddressResponseDto?> GetAsync(int contactId, int addressId);
    Task<AddressResponseDto> UpdateAsync(int contactId, int addressId, AddressUpdateDto addressUpdateDto);
    Task<AddressResponseDto> DeleteAsync(int contactId, int addressId);
    Task<List<AddressResponseDto>> ListAsync(int contactId);
}