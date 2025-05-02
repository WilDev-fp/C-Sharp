using Microsoft.AspNetCore.Mvc;
using RentalCarsWithRepositoryDesignPattern.Application.Dtos;
using RentalCarsWithRepositoryDesignPattern.Application.IServices;

namespace RentalCarsWithRepositoryDesignPattern.Presentation.Controllers;

[Route("rental-cars")]
[ApiController]
public class RentalCarController : ControllerBase
{
    private readonly ILogger<RentalCarController> _logger;
    private readonly IRentalService _rentalService;

    public RentalCarController(ILogger<RentalCarController> logger, IRentalService rentalService)
    {
        _logger = logger;
        _rentalService = rentalService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] RentalCarDto rentalCarDto)
    {
        var car = await _rentalService.Add(rentalCarDto);
        return Ok(car);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var listCar = await _rentalService.GetAll();
        return Ok(listCar);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        if (id <= 0)
        {
            return Forbid("Id must be a positive number!");
        }
        var isDeleted = await _rentalService.Delete(id);

        if (isDeleted)
        {
            return Ok($"Rental car with id: {id} was deleted correctly!");
        }

        return NotFound();
    }
}