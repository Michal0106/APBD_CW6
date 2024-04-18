using AnimalDataAPI.Models;
using AnimalDataAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AnimalDataAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    private readonly IAnimalService _animalService;
    
    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public IActionResult GetAnimals(String orderBy = "name")
    {
        var animals = _animalService.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        _animalService.AddAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        _animalService.UpdateAnimal(id, animal);
        return NoContent();
    }

    [HttpDelete("/{idAnimal:int}")]
    public IActionResult RemoveAnimal(int idAnimal)
    {
        var affected = _animalService.RemoveAnimal(idAnimal);
        return NoContent();
    }
}