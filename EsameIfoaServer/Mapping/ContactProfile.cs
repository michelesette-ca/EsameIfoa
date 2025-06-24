using AutoMapper;
using EsameIfoaServer.Domain.Model;
using EsameIfoaServer.Dto;

namespace EsameIfoaServer.Mapping;

public class ContactProfile : Profile
{
  public ContactProfile() 
  {
    CreateMap<Contact, ContactDto>().ReverseMap();
  }
}
