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
    public IActionResult CreateAnimal([FromBody] Animal student)
    {
        var affectedCount = _animalsService.CreateAnimal(student);
        return StatusCode(StatusCodes.Status201Created);
    }
}