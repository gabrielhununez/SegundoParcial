using SegundoParcial.Abstractions.DTOs;
using SegundoParcial.Abstractions.Interfaces;

namespace SegundoParcial.Consumer.Services;

public class BackendClient(HttpClient _client) : IBackendClient
{
    public async Task<IEnumerable<AnimalDTO>> GetAllAnimalsAsync()
    {
        return await _client.GetFromJsonAsync<IEnumerable<AnimalDTO>>("/api/Animal/GetAllAnimals");
    }
}