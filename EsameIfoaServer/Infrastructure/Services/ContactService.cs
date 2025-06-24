using AutoMapper;
using EsameIfoaServer.Domain.Model;
using EsameIfoaServer.Domain.Repositories;
using EsameIfoaServer.Domain.Services;
using EsameIfoaServer.Dto;

namespace EsameIfoaServer.Infrastructure.Services;

public class ContactService(IMapper mapper, IContactRepository contactRepository) : IContactService
{
  public async Task AddContact(ContactDto dto, CancellationToken cancellationToken)
  {
    var contact = mapper.Map<Contact>(dto);
    await contactRepository.AddContact(contact, cancellationToken);

  }

  public async Task<IEnumerable<ContactDto>> GetContactsAsync(CancellationToken cancellationToken)
  {
    var contacts = await contactRepository.GetContactsAsync(cancellationToken);
    return mapper.Map<IEnumerable<ContactDto>>(contacts);
  }
}
