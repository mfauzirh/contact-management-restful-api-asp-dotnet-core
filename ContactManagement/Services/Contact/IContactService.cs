using ContactManagement.Dtos;

namespace ContactManagement.Services;

public interface IContactService
{
    Task<ContactResponseDto> AddAsync(string userName, ContactCreateDto contactCreateDto);
}