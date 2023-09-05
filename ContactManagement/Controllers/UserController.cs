using ContactManagement.Dtos;
using ContactManagement.Models;
using ContactManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userName}")]
    public async Task<ActionResult<Response<UserResponseDto>>> Get(string userName)
    {
        var response = new Response<UserResponseDto>()
        {
            Data = await _userService.GetAsync(userName)
        };

        return Ok(response);
    }

    [HttpPatch("userName")]
    public async Task<ActionResult<Response<UserResponseDto>>> Update(string userName, UserUpdateDto request)
    {
        var response = new Response<UserResponseDto>()
        {
            Data = await _userService.UpdateAsync(userName, request)
        };

        return Ok(response);
    }
}