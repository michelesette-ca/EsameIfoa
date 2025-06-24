using System.ComponentModel.DataAnnotations;

namespace EsameIfoaServer.Domain.Model;

public class Contact
{
  public required int Id { get; set; }
  [MaxLength(100)]
  public required string FullName { get; set; }
  public required string Email { get; set; }
  [MaxLength(15)]
  public required string Phone { get; set; }
  public required string Department { get; set; }
}
