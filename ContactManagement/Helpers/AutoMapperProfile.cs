using AutoMapper;
using ContactManagement.Dtos;
using ContactManagement.Models;

namespace ContactManagement.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserResponseDto>().ReverseMap();
        CreateMap<User, UserRegisterDto>().ReverseMap();
        CreateMap<Contact, ContactResponseDto>().ReverseMap();
        CreateMap<Contact, ContactCreateDto>().ReverseMap();
    }
}