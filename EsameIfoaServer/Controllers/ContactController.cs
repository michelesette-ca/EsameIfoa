using EsameIfoaServer.Domain.Services;
using EsameIfoaServer.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EsameIfoaServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController(IContactService contactService): ControllerBase
{
  // GET: api/<ContactController>
  [HttpGet]
  public async Task<IEnumerable<ContactDto>> GetAll(CancellationToken cancellationToken)
  {
    return await contactService.GetContactsAsync(cancellationToken);
  }

  // POST api/<ContactController>
  [HttpPost]
  public async Task<IActionResult> Post(ContactDto dto, CancellationToken cancellationToken)
  {
    await contactService.AddContact(dto, cancellationToken);
    return Ok(new { message = "Contact created successfully!" });

  }
}
