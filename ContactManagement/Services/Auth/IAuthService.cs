using ContactManagement.Dtos;
using ContactManagement.Models;

namespace ContactManagement.Services;

public interface IAuthService
{
    Task<Response<UserGetDto>> Register(UserRegisterDto registerUser);
    Task<Response<string>> Login(UserLoginDto loginUser);
    Task<bool> UserExists(string userName);
}