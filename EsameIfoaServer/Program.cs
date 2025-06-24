using EsameIfoaServer.Domain.Model;
using EsameIfoaServer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
      Id = 1,
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
