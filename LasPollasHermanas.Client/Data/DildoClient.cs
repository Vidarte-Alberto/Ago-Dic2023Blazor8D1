namespace LasPollasHermanas.Client.Data;
using LasPollasHermanas.Client.Models;
using System.Net.Http.Json;
public class DildoClient
{
    private readonly HttpClient httpClient;

    public DildoClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<Dildo[]?> GetDildosAsync()
    {
        return await httpClient.GetFromJsonAsync<Dildo[]>("dildos");
    }

    public async Task AddDildoAsync(Dildo dildo)
    {
        await httpClient.PostAsJsonAsync("dildos", dildo);
    }

    public async Task<Dildo> GetDildoAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<Dildo>($"dildos/{id}") ??
        throw new Exception("Could not find dildo");
    }

    public async Task UpdateDildoAsync(Dildo updatedDildo)
    {
        await httpClient.PutAsJsonAsync($"dildos/{updatedDildo.Id}", updatedDildo);
    }

    public async Task DeleteDildoAsync(int id)
    {
        await httpClient.DeleteAsync($"dildos/{id}");
    }

    public async Task<Dildo[]?> SearchDildosAsync(string query)
    {
        return await httpClient.GetFromJsonAsync<Dildo[]>($"dildos/search/{query}");
    }
}