using EsameIfoaServer.Domain.Model;
using EsameIfoaServer.Domain.Repositories;
using EsameIfoaServer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EsameIfoaServer.Infrastructure.Repositories;

public class ContactRepository(DataContext context) : IContactRepository
{
  public async Task AddContact(Contact contact, CancellationToken cancellationToken)
  {
    await context.Contacts.AddAsync(contact, cancellationToken);
    await context.SaveChangesAsync();
  }

  public async Task<IEnumerable<Contact>> GetContactsAsync(CancellationToken cancellationToken)
  {
    return await context.Contacts.ToListAsync(cancellationToken);
  }
}
