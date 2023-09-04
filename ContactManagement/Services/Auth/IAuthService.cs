using ContactManagement.Dtos;
using ContactManagement.Models;

namespace ContactManagement.Services;

public interface IAuthService
{
    Task<UserResponseDto> Register(UserRegisterDto registerUser);
    Task<string> Login(UserLoginDto loginUser);
    Task<bool> UserExists(string userName);
}