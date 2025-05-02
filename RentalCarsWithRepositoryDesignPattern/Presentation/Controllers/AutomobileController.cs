using Microsoft.AspNetCore.Mvc;
using RentalCarsWithRepositoryDesignPattern.Application.Dtos;
using RentalCarsWithRepositoryDesignPattern.Application.IServices;

namespace RentalCarsWithRepositoryDesignPattern.Presentation.Controllers;

[Route("cars")]
[ApiController]
public class AutomobileController(ILogger<AutomobileController> logger, IAutomobileService automobileService) : ControllerBase
{
    private readonly ILogger<AutomobileController> _logger = logger;
    private readonly IAutomobileService _carService = automobileService;

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AutomobileDto automobileDto)
    {
        var car = await _carService.Add(automobileDto);
        return Ok(car);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var listCar = await _carService.GetAll();
        return Ok(listCar);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        if (id <= 0)
        {
            return Forbid("Id must be a positive number!");
        }
        var isDeleted = await _carService.Delete(id);

        if (isDeleted)
        {
            return Ok($"Car with id: {id} was deleted correctly!");
        }

        return NotFound();
    }
}
