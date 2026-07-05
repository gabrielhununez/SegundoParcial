using Microsoft.AspNetCore.Mvc;
using SegundoParcial.Abstractions.DTOs;
using SegundoParcial.Abstractions.Interfaces;

namespace SegundoParcial.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController(IAnimalRepository _animalRepository) : ControllerBase
{
    [HttpGet("GetAllAnimals")]
    public async Task<IActionResult> GetAllAnimals()
    {
        var animales = await _animalRepository.GetAllAnimal();

        return Ok(animales);
    }

    [HttpGet("GetAnimalByName/{name}")]
    public async Task<IActionResult> GetAnimalByName(string name)
    {
        var animal = await _animalRepository.GetAnimalByName(name);

        if(animal == null)
        {
            return NoContent();
        }

        return Ok(animal);
    }

    [HttpPut("DeleteAnimal/{id}")]
    public async Task<IActionResult> DeleteAnimalById(int id)
    {
        var animalBorrado = await _animalRepository.DeleteAnimalById(id);
        return Ok(animalBorrado);
    }

    [HttpPost("AddAnimal")]
    public async Task<IActionResult> AddAnimal([FromBody]AnimalRequestDto animalAAgregar)
    {
        var nuevoAnimalId = await _animalRepository.AddNewAnimal(animalAAgregar);
        return Ok(nuevoAnimalId);
    }
}