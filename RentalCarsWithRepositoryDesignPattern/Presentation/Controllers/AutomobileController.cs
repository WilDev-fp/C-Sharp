using Microsoft.AspNetCore.Mvc;
using RentalCarsWithRepositoryDesignPattern.Application.Dtos;
using RentalCarsWithRepositoryDesignPattern.Application.IServices;

namespace RentalCarsWithRepositoryDesignPattern.Presentation.Controllers;

[Route("cars")]
[ApiController]
public class AutomobileController : ControllerBase
{
    private readonly ILogger<AutomobileController> _logger;
    private readonly IAutomobileService _carService;

    public AutomobileController(ILogger<AutomobileController> logger, IAutomobileService automobileService)
    {
        _logger = logger;
        _carService = automobileService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AutomobileDto automobileDto)
    {
        var car = await _carService.Add(automobileDto);
        return Ok(car);
    }

    [HttpGet]
    public async Task<IActionResult> ReadAll()
    {
        var listCar = await _carService.GetAll();
        return Ok(listCar);
    }
}
