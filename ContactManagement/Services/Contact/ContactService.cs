using System.Net;
using AutoMapper;
using ContactManagement.Dtos;
using ContactManagement.Exceptions;
using ContactManagement.Models;
using ContactManagement.Repositories;

namespace ContactManagement.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ContactService(IContactRepository contactRepository, IUserRepository userRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ContactResponseDto> AddAsync(string userName, ContactCreateDto contactCreateDto)
    {
        User? user = await _userRepository.GetAsync(userName);

        if (user is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"User with username {userName} is not found.");
        }

        Contact contact = _mapper.Map<Contact>(contactCreateDto);
        contact.User = user;

        Contact createdContact = await _contactRepository.AddAsync(contact);

        return _mapper.Map<ContactResponseDto>(createdContact);
    }

    public async Task<ContactResponseDto> DeleteAsync(string userName, int contactId)
    {
        User? user = await _userRepository.GetAsync(userName);

        if (user is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"User with username {userName} is not found.");
        }

        Contact? contact = await _contactRepository.GetAsync(contactId);

        if (contact is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"Contact with contactId {contactId} is not found.");
        }

        Contact deletedContact = await _contactRepository.DeleteAsync(contact);

        return _mapper.Map<ContactResponseDto>(deletedContact);
    }

    public async Task<ContactResponseDto> GetAsync(string userName, int contactId)
    {
        User? user = await _userRepository.GetAsync(userName);

        if (user is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"User with username {userName} is not found.");
        }

        Contact? contact = await _contactRepository.GetAsync(contactId);

        if (contact is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"Contact with contactId {contactId} is not found.");
        }

        return _mapper.Map<ContactResponseDto>(contact);
    }

    public async Task<List<ContactResponseDto>> SearchAsync(string userName, ContactSearchDto contactSearchDto)
    {
        User? user = await _userRepository.GetAsync(userName);

        if (user is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"User with username {userName} is not found.");
        }

        List<Contact> contacts = await _contactRepository.SearchAsync(userName, contactSearchDto);

        return _mapper.Map<List<ContactResponseDto>>(contacts);
    }

    public async Task<ContactResponseDto> UpdateAsync(string userName, int contactId, ContactUpdateDto contactUpdateDto)
    {
        User? user = await _userRepository.GetAsync(userName);

        if (user is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"User with username {userName} is not found.");
        }

        Contact? contact = await _contactRepository.GetAsync(contactId);

        if (contact is null)
        {
            throw new ResponseException(HttpStatusCode.NotFound, $"Contact with contactId {contactId} is not found.");
        }

        contact.FirstName = contactUpdateDto.FirstName;
        contact.LastName = contactUpdateDto.LastName;
        contact.Email = contactUpdateDto.Email;
        contact.Phone = contactUpdateDto.Phone;

        Contact updatedContact = await _contactRepository.UpdateAsync(contact);

        return _mapper.Map<ContactResponseDto>(updatedContact);
    }
}