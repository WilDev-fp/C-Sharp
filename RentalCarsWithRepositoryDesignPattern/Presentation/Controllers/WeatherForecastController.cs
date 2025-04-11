using Microsoft.AspNetCore.Mvc;
using RentalCarsWithRepositoryDesignPattern.Infrastructure.Context;

namespace RentalCarsWithRepositoryDesignPattern.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        return Ok("void result for this get");
    }
}
