using AutoMapper;
using ContactManagement.Data;
using ContactManagement.Dtos;
using ContactManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ContactRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Contact> AddAsync(Contact contact)
    {
        await _context.Contacts.AddAsync(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact> DeleteAsync(Contact contact)
    {
        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact?> GetAsync(int contactId)
    {
        return await _context.Contacts.FindAsync(contactId);
    }

    public async Task<ContactSearchResultDto> SearchAsync(string userName, ContactSearchDto searchBy)
    {
        var query = _context.Contacts.AsQueryable();

        query = query.Where(c => c.UserName == userName);

        if (!string.IsNullOrEmpty(searchBy.Name))
        {
            query = query.Where(c => c.FirstName.Contains(searchBy.Name) || (c.LastName != null && c.LastName.Contains(searchBy.Name)));
        }

        if (!string.IsNullOrEmpty(searchBy.Email))
        {
            query = query.Where(c => c.Email != null && c.Email.Contains(searchBy.Email));
        }

        if (!string.IsNullOrEmpty(searchBy.Phone))
        {
            query = query.Where(c => c.Phone != null && c.Phone.Contains(searchBy.Phone));
        }

        var totalItems = await query.CountAsync();

        query = query.Skip((searchBy.Page - 1) * searchBy.Size).Take(searchBy.Size);

        var contacts = await query.ToListAsync();

        return new ContactSearchResultDto
        {
            Contacts = _mapper.Map<List<ContactResponseDto>>(contacts),
            Page = searchBy.Page,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double)searchBy.Size)
        };
    }

    public async Task<Contact> UpdateAsync(Contact contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
        return contact;
    }
}