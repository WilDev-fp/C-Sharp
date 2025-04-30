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
    public async Task<IActionResult> Create([FromBody] RentalCarDto rentalCarDto)
    {
        var car = await _rentalService.Add(rentalCarDto);
        return Ok(car);
    }

    [HttpGet]
    public async Task<IActionResult> ReadAll()
    {
        var listCar = await _rentalService.GetAll();
        return Ok(listCar);
    }
}