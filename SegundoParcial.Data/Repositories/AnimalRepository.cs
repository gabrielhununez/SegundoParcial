using Microsoft.EntityFrameworkCore;
using SegundoParcial.Abstractions.DTOs;
using SegundoParcial.Abstractions.Interfaces;
using SegundoParcial.Data.EF;
using SegundoParcial.Data.Models;

namespace SegundoParcial.Data.Repository;

public class AnimalRepository(DBContext _context) : IAnimalRepository
{
    public async Task<IEnumerable<AnimalDTO>> GetAllAnimal()
    {
        var animales = await (
            from a in _context.Animales
            where a.IsDelete == false
            select new AnimalDTO
            {
                Name = a.Name,
                Description = a.Description,
                Age = a.Age
            }).ToListAsync();

        return animales;
    }


    public async Task<AnimalDTO?> GetAnimalByName(string name)
    {
        var animal = await (
            from a in _context.Animales
            where a.IsDelete == false &&
            a.Name.Contains(name)
            select new AnimalDTO
            {
                Name = a.Name,
                Description = a.Description,
                Age = a.Age
            }).FirstOrDefaultAsync();

        return animal ?? null;
    }
    
    public async Task<bool> DeleteAnimalById(long id)
    {
        var animalABorrar = await _context.Animales.Where(a => a.AnimalId == id).FirstOrDefaultAsync();
        if (animalABorrar == null) return false;

        animalABorrar.IsDelete = true;
        animalABorrar.UpdateOn = DateTime.Now;
        animalABorrar.UpdateBy = "DeleteAnimalById";
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<long> AddNewAnimal(AnimalRequestDto animalAAgregar)
    {
        //En caso de que tenga relacion deberia buscar la raza y en caso de no tenerla, deberia crearla
        /*
         var raza = await _context.Razas.Where(r => r.IsDelete && r.Name == animalAAgregar.NombreRaza).FirstOrDefaultAsync();

        if(raza == null)
        {
            raza = new Models.Raza();
            raza.Name = animalAAgregar.NombreRaza;
            await _context.Razas.AddAsync(raza);
        }
        */

        var animal = new Animal();
        animal.Name = animalAAgregar.Name;
        animal.Description = animalAAgregar.Description;
        animal.Age = animalAAgregar.Age;
        animal.IsDelete = false;
        //animal.raza = animalAAgregar.Raza;
        animal.CreatedOn = DateTime.Now;
        animal.CreatedBy = "AddNewAnimal";

        await _context.Animales.AddAsync(animal);
        await _context.SaveChangesAsync();

        return animal.AnimalId;
    }
}