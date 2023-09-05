using ContactManagement.Dtos;

namespace ContactManagement.Services;

public interface IContactService
{
    Task<ContactResponseDto> AddAsync(string userName, ContactCreateDto contactCreateDto);
    Task<ContactResponseDto> GetAsync(string userName, int contactId);
    Task<ContactResponseDto> UpdateAsync(string userName, int contactId, ContactUpdateDto contactUpdateDto);
    Task<ContactResponseDto> DeleteAsync(string userName, int contactId);
    Task<ContactSearchResultDto> SearchAsync(string userName, ContactSearchDto contactSearchDto);
}