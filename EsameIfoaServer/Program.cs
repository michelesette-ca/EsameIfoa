using EsameIfoaServer.Domain.Model;
using EsameIfoaServer.Domain.Repositories;
using EsameIfoaServer.Domain.Services;
using EsameIfoaServer.Infrastructure.Data;
using EsameIfoaServer.Infrastructure.Repositories;
using EsameIfoaServer.Infrastructure.Services;
using EsameIfoaServer.Mapping;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAllOrigins",
      builder =>
      {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
      });
});

builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddAutoMapper(typeof(ContactProfile));


builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer("Server=localhost;Database=EsameIfoa;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

// Seed iniziale 
using (var scope = app.Services.CreateScope())
{
  var context = scope.ServiceProvider.GetRequiredService<DataContext>();

  context.Database.EnsureDeleted();
  context.Database.EnsureCreated();

  if (!context.Contacts.Any())
  {
    context.Contacts.AddRange(
    new Contact
    {
      Id = 0,
      FullName = "Mario Rossi",
      Email = "mario@example.com",
      Phone = "1234567890",
      Department = "IT"
    },
    new Contact
    {
      Id = 0,
      FullName = "Giulio Verdi",
      Email = "giulio@example.com",
      Phone = "789456123",
      Department = "IT"
    }
   );
    context.SaveChanges();
  }
}

app.Run();
