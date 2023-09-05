using System.Net;
using AutoMapper;
using ContactManagement.Dtos;
using ContactManagement.Exceptions;
using ContactManagement.Models;
using ContactManagement.Repositories;
using Bcrypt = BCrypt.Net.BCrypt;

namespace ContactManagement.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserResponseDto> GetAsync(string userName)
    {
        User? user = await _userRepository.GetAsync(userName);

        if (user is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"User with username {userName} is not found.");
        }

        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task<UserResponseDto> UpdateAsync(string userName, UserUpdateDto request)
    {
        User? user = await _userRepository.GetAsync(userName);

        if (user is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"User with username {userName} is not found.");
        }

        user.Password = request.Password is not null ? Bcrypt.HashPassword(request.Password) : user.Password;
        user.Name = request.Name is not null ? request.Name : user.Name;

        User updatedUser = await _userRepository.UpdateAsync(user);

        return _mapper.Map<UserResponseDto>(updatedUser);
    }

    public async Task<bool> UserExists(string userName)
    {
        return await _userRepository.GetAsync(userName) is not null;
    }
}