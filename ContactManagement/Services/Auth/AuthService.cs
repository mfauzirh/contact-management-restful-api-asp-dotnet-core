using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using AutoMapper;
using ContactManagement.Dtos;
using ContactManagement.Exceptions;
using ContactManagement.Models;
using ContactManagement.Repositories;
using Microsoft.IdentityModel.Tokens;
using Bcrypt = BCrypt.Net.BCrypt;

namespace ContactManagement.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<UserResponseDto> Register(UserRegisterDto registerUser)
    {
        if (await UserExists(registerUser.UserName))
        {
            throw new ResponseException(HttpStatusCode.Conflict, $"User with username {registerUser.UserName} is already exists.");
        }

        registerUser.Password = Bcrypt.HashPassword(registerUser.Password);

        User registeredUser = await _userRepository.AddAsync(_mapper.Map<User>(registerUser));

        return _mapper.Map<UserResponseDto>(registeredUser);
    }

    public async Task<string> Login(UserLoginDto loginUser)
    {
        User? user = await _userRepository.GetAsync(loginUser.UserName);

        if (user is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"User with username '{loginUser.UserName}' is not found.");
        }

        if (!Bcrypt.Verify(loginUser.Password, user.Password))
        {
            throw new ResponseException(HttpStatusCode.Unauthorized, "Username or password wrong.");
        }

        string token = CreateToken(user);

        return token;
    }

    public async Task<bool> UserExists(string userName)
    {
        return await _userRepository.GetAsync(userName) is not null;
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserName),
        };

        string? appSettingsToken = _configuration.GetSection("AppSettings:Token").Value ?? throw new Exception("AppSettings Token is null");

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingsToken));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes(30),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}