using APBD_5.Models;
using APBD_5.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_5.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalsService _animalsService;

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }
 
    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string? orderBy)
    {
        if (string.IsNullOrEmpty(orderBy))
            orderBy = "name";
        
        if (orderBy != "name" && orderBy != "description" && orderBy != "category" && orderBy != "area")
            return BadRequest("Invalid argument");

        orderBy = orderBy[0].ToString().ToUpper() + orderBy.Substring(1);
        
        var animals = _animalsService.GetAnimals(orderBy);
        return Ok(animals);
    }
    
    [HttpPost]
    public IActionResult CreateAnimal([FromBody] Animal animal)
    {
        var affectedCount = _animalsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{idAnimal:int}")]
    public IActionResult UpdateAnimal([FromBody] Animal animal, int idAnimal)
    {
        var affectedCount = _animalsService.UpdateAnimal(animal, idAnimal);
        if (affectedCount == 0)
            return NotFound("Animal with id " + idAnimal + " not found");
        return NoContent();
    }
    
    [HttpDelete("{idAnimal:int}")]
    public IActionResult DeleteAnimal(int idAnimal)
    {
        var affectedCount = _animalsService.DeleteAnimal(idAnimal);
        if (affectedCount == 0)
            return NotFound("Animal with id " + idAnimal + " not found");
        return NoContent();
    }
}