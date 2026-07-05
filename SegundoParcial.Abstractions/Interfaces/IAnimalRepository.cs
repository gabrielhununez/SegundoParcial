using SegundoParcial.Abstractions.DTOs;

namespace SegundoParcial.Abstractions.Interfaces;

public interface IAnimalRepository
{
    Task<IEnumerable<AnimalDTO>> GetAllAnimal();
    Task<AnimalDTO?> GetAnimalByName(string name);
    Task<bool> DeleteAnimalById(long id);
    Task<long> AddNewAnimal(AnimalRequestDto animalAAgregar);
}