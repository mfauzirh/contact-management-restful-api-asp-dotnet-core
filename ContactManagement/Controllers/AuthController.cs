using System.Net;
using ContactManagement.Dtos;
using ContactManagement.Models;
using ContactManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<Response<UserResponseDto>>> Register(UserRegisterDto registerUser)
    {
        var response = new Response<UserResponseDto>()
        {
            Data = await _authService.Register(registerUser)
        };

        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<Response<string>>> Login(UserLoginDto loginUser)
    {
        var response = new Response<string>()
        {
            Data = await _authService.Login(loginUser)
        };

        return Ok(response);
    }
}