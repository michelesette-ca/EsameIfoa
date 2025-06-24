using EsameIfoaServer.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EsameIfoaServer.Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
  public DbSet<Contact> Contacts { get; set; }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Contact>()
        .Property(c => c.FullName)
        .HasMaxLength(100);
    modelBuilder.Entity<Contact>()
        .Property(c => c.Phone)
        .HasMaxLength(15);
  }
}

