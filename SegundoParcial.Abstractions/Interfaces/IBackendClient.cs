using SegundoParcial.Abstractions.DTOs;

namespace SegundoParcial.Abstractions.Interfaces;

public interface IBackendClient
{
    Task<IEnumerable<AnimalDTO>> GetAllAnimalsAsync();
}