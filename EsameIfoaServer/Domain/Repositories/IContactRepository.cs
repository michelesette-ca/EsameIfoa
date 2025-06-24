using EsameIfoaServer.Domain.Model;

namespace EsameIfoaServer.Domain.Repositories;

public interface IContactRepository
{
  public Task<IEnumerable<Contact>> GetContactsAsync(CancellationToken cancellationToken);
  public Task AddContact(Contact contact, CancellationToken cancellationToken);
}
