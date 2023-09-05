using System.Net;
using ContactManagement.Dtos;
using ContactManagement.Models;
using ContactManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpPost]
    public async Task<ActionResult<Response<ContactResponseDto>>> Add(ContactCreateDto request)
    {
        var userName = HttpContext.Items["userName"] as string;

        var response = new Response<ContactResponseDto>()
        {
            Data = await _contactService.AddAsync(userName!, request)
        };

        return StatusCode((int)HttpStatusCode.Created, response);
    }
}