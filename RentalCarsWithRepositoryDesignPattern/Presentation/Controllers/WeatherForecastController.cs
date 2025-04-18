using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RentalCarsWithRepositoryDesignPattern.Application.IRepositories;
using RentalCarsWithRepositoryDesignPattern.Application.IServices;
using RentalCarsWithRepositoryDesignPattern.Domain.Data;
using RentalCarsWithRepositoryDesignPattern.Infrastructure.Context;

namespace RentalCarsWithRepositoryDesignPattern.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IAutomobileService _carService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IAutomobileService automobileService)
    {
        _logger = logger;
        _carService = automobileService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        return Ok("void result for this get");
    }

    [HttpPost]
    public IActionResult Post([FromBody] Automobile car)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _carService.Add(car);
        
        return Ok("GetProduct");
    }
}
