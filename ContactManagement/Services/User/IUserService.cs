using ContactManagement.Dtos;
using ContactManagement.Models;

namespace ContactManagement.Services;

public interface IUserService
{
    Task<UserResponseDto> GetAsync(string userName);
    Task<UserResponseDto> UpdateAsync(string userName, UserUpdateDto request);
    Task<bool> UserExists(string userName);
}