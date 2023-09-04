using ContactManagement.Dtos;
using ContactManagement.Models;

namespace ContactManagement.Services;

public interface IUserService
{
    Task<UserResponseDto> GetAsync(string userName);
    Task<Response<UserResponseDto>> Update(UserUpdateDto request);
    Task<bool> UserExists(string userName);
}