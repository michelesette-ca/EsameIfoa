using EsameIfoaServer.Domain.Model;
using EsameIfoaServer.Dto;

namespace EsameIfoaServer.Domain.Services;

public interface IContactService
{
  public Task<IEnumerable<ContactDto>> GetContactsAsync(CancellationToken cancellationToken);
  public Task AddContact(ContactDto dto, CancellationToken cancellationToken);
}
