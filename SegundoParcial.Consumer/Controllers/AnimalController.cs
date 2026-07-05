using Microsoft.AspNetCore.Mvc;
using SegundoParcial.Abstractions.Interfaces;

namespace SegundoParcial.Consumer.Controllers;

[Route("[controller]")]
[ApiController]
public class AnimalController(IBackendClient _backendClient) : ControllerBase
{
    [HttpGet("getAllAnimalFromBackend")]
    public async Task<IActionResult> GetAllAnimalsFromBackend()
    {
        var animals = await _backendClient.GetAllAnimalsAsync();
        return Ok(animals);
    }
}