using System.Net;
using ContactManagement.Dtos;
using ContactManagement.Models;
using ContactManagement.Repositories;
using ContactManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Controllers;

[Authorize]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost("/api/contact/{contactId}/address")]
    public async Task<ActionResult<Response<AddressResponseDto>>> Add(int contactId, AddressCreateDto request)
    {

        var response = new Response<AddressResponseDto>
        {
            Data = await _addressService.AddAsync(contactId, request)
        };

        return StatusCode((int)HttpStatusCode.Created, response);
    }

    [HttpGet("/api/contact/{contactId}/address/{addressId}")]
    public async Task<ActionResult<Response<AddressResponseDto>>> Get(int contactId, int addressId)
    {

        var response = new Response<AddressResponseDto>
        {
            Data = await _addressService.GetAsync(contactId, addressId)
        };

        return Ok(response);
    }
}