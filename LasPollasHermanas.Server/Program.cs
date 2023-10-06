using LasPollasHermanas.Server.Models;
using Microsoft.EntityFrameworkCore;

List<Dildo> dildos = new ()
    {
        new Dildo () 
        {
            Id = 1,
            Name = "Dildo Hulk",
            Price = 3000M,
            Size = 45.3M,
            ExpireDate = new DateTime(2026, 04, 23)
        },
        new Dildo () 
        {
            Id = 2,
            Name = "Dildo De Amazon",
            Price = 7000M,
            Size = 23.1M,
            ExpireDate = new DateTime(2030, 03, 12)
        },
        new Dildo () 
        {
            Id = 3,
            Name = "Dildo Hydra",
            Price = 1500M,
            Size = 10.1M,
            ExpireDate = new DateTime(2027, 06, 10)
        },
        new Dildo () 
        {
            Id = 4,
            Name = "Dildo Dragon de Dos Cabezas",
            Price = 2000M,
            Size = 20.2M,
            ExpireDate = new DateTime(2029, 10, 1)
        }
    };

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => options.AddDefaultPolicy(
    builder =>
    {
    builder.WithOrigins("http://localhost:5289")
    .AllowAnyHeader()
    .AllowAnyMethod();
}));
var connectionString = builder.Configuration.GetConnectionString("DildoStoreContext");
builder.Services.AddSqlServer<DildoStoreContext>(connectionString);
var app = builder.Build();
app.UseCors();
var dildoGroup = app.MapGroup("/dildos").WithParameterValidation();
#region Entry Points Dildos
// EndPoint
// GET Dildos
dildoGroup.MapGet("/", async (DildoStoreContext context) =>
await context.Dildos.AsNoTracking().ToListAsync());

// GET/Dildo/{id}
dildoGroup.MapGet("/{id}", async (int id, DildoStoreContext context) => 
{
    Dildo? dildo = await context.Dildos.FindAsync(id);
    if(dildo is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(dildo);
});

// POST/dildos
dildoGroup.MapPost("/", async (Dildo dildo, DildoStoreContext context) =>
{
    // TODO: Where the F this id comes?
    context.Dildos.Add(dildo);
    await context.SaveChangesAsync();
    return Results.CreatedAtRoute("GetDildo", 
    new {id = dildo.Id}, dildo);
}).WithName("GetDildo");

// PUT/dildos/{id}
dildoGroup.MapPut("/{id}",async (int id, Dildo updatedDildo, DildoStoreContext context) =>
{
    Dildo? existingDildo = await context.Dildos.FindAsync(id);
    if(existingDildo is null)
    {
        updatedDildo.Id = id;
        context.Dildos.Add(updatedDildo);
        await context.SaveChangesAsync();
        return Results.CreatedAtRoute("UpdateDildo",
        new {id = updatedDildo.Id}, updatedDildo);
    }
    existingDildo.Name = updatedDildo.Name;
    existingDildo.Price = updatedDildo.Price;
    existingDildo.Size = updatedDildo.Size;
    existingDildo.ExpireDate = updatedDildo.ExpireDate;
    existingDildo.Material = updatedDildo.Material;
    existingDildo.Color = updatedDildo.Color;
    existingDildo.Stock = updatedDildo.Stock;
    await context.SaveChangesAsync();
    return Results.NoContent();
});

dildoGroup.MapDelete("/{id}", async (int id, DildoStoreContext context) =>
{
    Dildo? deletedDildo = await context.Dildos.FindAsync(id);
    if(deletedDildo is null)
    {
        return Results.NotFound();
    }
    context.Dildos.Remove(deletedDildo);
    await context.SaveChangesAsync();
    return Results.NoContent();
}
);
#endregion

app.Run();
