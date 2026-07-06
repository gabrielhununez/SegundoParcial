using Microsoft.AspNetCore.Mvc;
using Moq;
using SegundoParcial.Abstractions.DTOs;
using SegundoParcial.Abstractions.Interfaces;
using SegundoParcial.Backend.Controllers;
using System.Net;

namespace XUnitSegundoParcial;

public class SegundoParcialConsumerTest
{
    [Fact]
    public async Task ProbarOK()
    {
        //ARRANGE
        var simulacion = new List<AnimalDTO>();
        simulacion.Add(new AnimalDTO { Name = "Kira", Description = "Perruno" });
        simulacion.Add(new AnimalDTO { Name = "Phoebe", Description = "Perruno" });

        var mockrepo = new Mock<IAnimalRepository>();
        mockrepo.Setup(r => r.GetAllAnimal()).ReturnsAsync(simulacion);

        var controller = new AnimalController(mockrepo.Object);

        //ACT
        var result = await controller.GetAllAnimals();

        //ASSERT
        Assert.IsType<OkObjectResult>(result);
    }

    //Si quisiera probar los dos casos con el mismo test, podría hacer algo así:

    [Theory]
    [InlineData(true, typeof(OkObjectResult))]
    [InlineData(false, typeof(NotFoundResult))]
    public async Task GetAllAnimals(bool tieneDatos, Type tipoEsperado)
    {
        List<AnimalDTO> simulacion = new List<AnimalDTO>();

        if (tieneDatos)
        {
            simulacion.Add(new AnimalDTO { Name = "Pepe", Description = "Loro" });
        }

        var mockrepo = new Mock<IAnimalRepository>();
        mockrepo.Setup(r => r.GetAllAnimal()).ReturnsAsync(simulacion);

        var controller = new AnimalController(mockrepo.Object);

        var result = await controller.GetAllAnimals();

        Assert.IsType(tipoEsperado, result);
    }
}