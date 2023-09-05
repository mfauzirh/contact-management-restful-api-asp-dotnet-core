using System.Net;
using AutoMapper;
using ContactManagement.Dtos;
using ContactManagement.Exceptions;
using ContactManagement.Models;

namespace ContactManagement.Repositories;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public AddressService(IAddressRepository addressRepository, IContactRepository contactRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _contactRepository = contactRepository;
        _mapper = mapper;
    }
    public async Task<AddressResponseDto> AddAsync(int contactId, AddressCreateDto addressCreateDto)
    {
        Contact? contact = await _contactRepository.GetAsync(contactId);

        if (contact is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"Contact with contactId {contactId} is not found.");
        }

        Address address = _mapper.Map<Address>(addressCreateDto);
        address.Contact = contact;

        Address createdAddress = await _addressRepository.AddAsync(address);

        return _mapper.Map<AddressResponseDto>(createdAddress);
    }

    public async Task<AddressResponseDto> DeleteAsync(int contactId, int addressId)
    {
        Contact? contact = await _contactRepository.GetAsync(contactId);

        if (contact is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"Contact with contactId {contactId} is not found.");
        }

        Address? address = await _addressRepository.GetAsync(contactId, addressId);

        if (address is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"Address with addressId {addressId} is not found.");
        }

        Address deletedAddress = await _addressRepository.DeleteAsync(address);

        return _mapper.Map<AddressResponseDto>(deletedAddress);
    }

    public async Task<AddressResponseDto?> GetAsync(int contactId, int addressId)
    {
        Contact? contact = await _contactRepository.GetAsync(contactId);

        if (contact is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"Contact with contactId {contactId} is not found.");
        }

        Address? address = await _addressRepository.GetAsync(contactId, addressId);

        if (address is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"Address with addressId {addressId} is not found.");
        }

        return _mapper.Map<AddressResponseDto>(address);
    }

    public async Task<List<AddressResponseDto>> ListAsync(int contactId)
    {
        Contact? contact = await _contactRepository.GetAsync(contactId);

        if (contact is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"Contact with contactId {contactId} is not found.");
        }

        List<Address> addresses = await _addressRepository.ListAsync(contactId);

        return _mapper.Map<List<AddressResponseDto>>(addresses);
    }

    public async Task<AddressResponseDto> UpdateAsync(int contactId, int addressId, AddressUpdateDto addressUpdateDto)
    {
        Contact? contact = await _contactRepository.GetAsync(contactId);

        if (contact is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"Contact with contactId {contactId} is not found.");
        }

        Address? address = await _addressRepository.GetAsync(contactId, addressId);

        if (address is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"Address with addressId {addressId} is not found.");
        }

        address.Street = addressUpdateDto.Street;
        address.City = addressUpdateDto.City;
        address.Province = addressUpdateDto.Province;
        address.Country = addressUpdateDto.Country;
        address.PostalCode = addressUpdateDto.PostalCode;

        Address updatedAddress = await _addressRepository.UpdateAsync(address);

        return _mapper.Map<AddressResponseDto>(updatedAddress);
    }
}