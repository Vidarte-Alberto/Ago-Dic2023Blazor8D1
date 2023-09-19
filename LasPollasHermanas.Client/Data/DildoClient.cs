namespace LasPollasHermanas.Client.Data;
using LasPollasHermanas.Client.Models;
public static class DildoClient
{
    private static List<Dildo> dildos = new ()
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

    public static Dildo[] GetDildos()
    {
        return dildos.ToArray();
    }

    public static void AddDildo(Dildo dildo)
    {
        dildo.Id = dildos.Max(dildo => dildo.Id) + 1;
        dildos.Add(dildo);
    }

    public static Dildo GetDildo(int id)
    {
        return dildos.Find(dildo => dildo.Id == id) ?? 
        throw new Exception("Could not find plush");
    }

    public static void UpdateDildo (Dildo updatedDildo)
    {
        Dildo existingDildo = GetDildo(updatedDildo.Id);
        existingDildo.Name = updatedDildo.Name;
        existingDildo.Price = updatedDildo.Price;
        existingDildo.Material = updatedDildo.Material;
        existingDildo.Size = updatedDildo.Size;
        existingDildo.ExpireDate = updatedDildo.ExpireDate;
        existingDildo.Color = updatedDildo.Color;
        existingDildo.Stock = updatedDildo.Stock;
    }

    public static void DeleteDildo(int id)
    {
        Dildo dildo = GetDildo(id);
        dildos.Remove(dildo);
    }
}