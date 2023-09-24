using LasPollasHermanas.Server.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var dildoGroup = app.MapGroup("/dildos").WithParameterValidation();


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

#region Entry Points Dildos
// EndPoint
// GET Dildos
dildoGroup.MapGet("/", () => dildos);

// GET/Dildo/{id}
dildoGroup.MapGet("/{id}", (int id) => 
{
    Dildo? dildo = dildos.Find(dildo => 
    dildo.Id == id);
    if(dildo is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(dildo);
});

// POST/dildos
dildoGroup.MapPost("/", (Dildo dildo) =>
{
    dildo.Id = dildos.Max(dildo => dildo.Id) + 1;
    dildos.Add(dildo);
    return Results.CreatedAtRoute("GetDildo", 
    new {id = dildo.Id}, dildo);
}).WithName("GetDildo");

// PUT/dildos/{id}
dildoGroup.MapPut("/{id}", (int id, Dildo updatedDildo) =>
{
    Dildo? existingDildo = dildos.Find(dildo => dildo.Id == id);
    if(existingDildo is null)
    {
        updatedDildo.Id = id;
        dildos.Add(updatedDildo);
        return Results.CreatedAtRoute("UpdateDildo",
        new {id = updatedDildo.Id}, updatedDildo);
    }
    int indexDildo = dildos.FindIndex(dildo => dildo.Id == id);
    updatedDildo.Id = id;
    dildos[indexDildo] = updatedDildo;
    // existingDildo.Name = updatedDildo.Name;
    // existingDildo.Price = updatedDildo.Price;
    // existingDildo.Size = updatedDildo.Size;
    // existingDildo.ExpireDate = updatedDildo.ExpireDate;
    // existingDildo.Material = updatedDildo.Material;
    // existingDildo.Color = updatedDildo.Color;
    // existingDildo.Stock = updatedDildo.Stock;
     
    return Results.NoContent();
});

dildoGroup.MapDelete("/{id}", (int id) =>
{
    Dildo? deletedDildo = dildos.Find(dildo => dildo.Id == id);
    if(deletedDildo is null)
    {
        return Results.NotFound();
    }
    dildos.Remove(deletedDildo);
    return Results.NoContent();
}
);
#endregion

app.Run();
