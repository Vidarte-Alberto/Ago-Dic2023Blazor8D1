namespace LasPollasHermanas.Client.Data;
using LasPollasHermanas.Client.Models;
public static class DildoClient
{
    private static List<Dildo> dildos = new()
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

    public static Dildo GetDildoById(int dildoId)
    {
        return dildos.FirstOrDefault(dildo => dildo.Id == dildoId);
    }


    public static void AddDildo(Dildo dildo)
    {
        dildo.Id = dildos.Max(dildo => dildo.Id) + 1;
        dildos.Add(dildo);
    }

    public static void RemoveDildo(int dildoId)
    {
        var dildoToRemove = dildos.FirstOrDefault(dildo => dildo.Id == dildoId);
        if (dildoToRemove != null)
        {
            dildos.Remove(dildoToRemove);
        }
    }

    public static void UpdateDildo(Dildo updatedDildo)
    {
        // Encuentra el dildo que coincide con el ID del updatedDildo
        var existingDildo = dildos.FirstOrDefault(dildo => dildo.Id == updatedDildo.Id);

        if (existingDildo != null)
        {
            // Actualiza las propiedades del dildo existente con los valores del updatedDildo
            existingDildo.Name = updatedDildo.Name;
            existingDildo.Price = updatedDildo.Price;
            existingDildo.Size = updatedDildo.Size;
            existingDildo.ExpireDate = updatedDildo.ExpireDate;
            existingDildo.Material = updatedDildo.Material;
            existingDildo.Color = updatedDildo.Color;
            existingDildo.Stock = updatedDildo.Stock;
        }
        else
        {
            throw new ArgumentException("El Dildo no se encontró y no puede ser actualizado.");
        }
    }

}