using System.Net.Http.Json;
using CursoAlura.Adopet.Console.Modelos;
using CursoAlura.Adopet.Console.Servicos.Abstracoes;

namespace CursoAlura.Adopet.Console.Servicos.Http;

public class PetService: IApiService<Pet>
{
    private HttpClient client;

    public PetService(HttpClient client)
    {
        this.client = client;
    }

    public virtual Task CreateAsync(Pet pet)
    {
        return client.PostAsJsonAsync("pet/add", pet);
    }

    public virtual async Task<IEnumerable<Pet>?> ListAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}
