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

        var response = new Response<ContactResponseDto>
        {
            Data = await _contactService.AddAsync(userName!, request)
        };

        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpGet("{contactId}")]
    public async Task<ActionResult<Response<ContactResponseDto>>> Get(int contactId)
    {
        var userName = HttpContext.Items["userName"] as string;

        var response = new Response<ContactResponseDto>
        {
            Data = await _contactService.GetAsync(userName!, contactId)
        };

        return Ok(response);
    }

    [HttpPut("{contactId}")]
    public async Task<ActionResult<Response<ContactResponseDto>>> Update(int contactId, ContactUpdateDto contactUpdateDto)
    {
        var userName = HttpContext.Items["userName"] as string;

        var response = new Response<ContactResponseDto>
        {
            Data = await _contactService.UpdateAsync(userName!, contactId, contactUpdateDto)
        };

        return Ok(response);
    }

    [HttpDelete("{contactId}")]
    public async Task<ActionResult<Response<ContactResponseDto>>> Delete(int contactId)
    {
        var userName = HttpContext.Items["userName"] as string;

        var response = new Response<ContactResponseDto>
        {
            Data = await _contactService.DeleteAsync(userName!, contactId)
        };

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<Response<ContactSearchResultDto>>> Search([FromQuery] ContactSearchDto contactSearchDto)
    {
        var userName = HttpContext.Items["userName"] as string;

        var response = new Response<ContactSearchResultDto>
        {
            Data = await _contactService.SearchAsync(userName!, contactSearchDto)
        };

        return Ok(response);
    }
}