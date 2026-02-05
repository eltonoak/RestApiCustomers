using RestApiCustomers.Data;
using RestApiCustomers.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=customers.db"));

var app = builder.Build();

// Criar a base de dados
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// POST /customers
app.MapPost("/customers", async (Customer customer, AppDbContext db) =>
{
    if (string.IsNullOrWhiteSpace(customer.Name))
        return Results.Conflict("O Nome é obrigatório");
    // Validar o formato do email
    var emailValidator = new EmailAddressAttribute();
    if (!emailValidator.IsValid(customer.Email))
        return Results.BadRequest("O Formato do email é inválido");

    // Verificar se email está disponível
    var exists = await db.Customers
        .AnyAsync(c => c.Email == customer.Email);

    if (exists)
        return Results.Conflict("O Email introduzido não está disponível.");

    db.Customers.Add(customer);
    await db.SaveChangesAsync();

    return Results.Created($"/customers/{customer.Id}", customer);
});

app.Run();

