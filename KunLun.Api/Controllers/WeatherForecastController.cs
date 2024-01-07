<<<<<<< HEAD
using Microsoft.AspNetCore.Authorization;
=======
>>>>>>> b4ef06f15defe758aee32d064e4d225ce982ce3f
using Microsoft.AspNetCore.Mvc;

namespace KunLun.Api.Controllers;

[ApiController]
<<<<<<< HEAD
[Authorize]
=======
>>>>>>> b4ef06f15defe758aee32d064e4d225ce982ce3f
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

<<<<<<< HEAD
    /// <summary>
    /// Get
    /// </summary>
    /// <returns>IEnumerable&lt;WeatherForecast&gt;</returns>
    [HttpGet(Name = "GetWeatherForecast")]
    [ProducesResponseType(typeof(IEnumerable<WeatherForecast>),200)]
    public Object Get()
=======
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
>>>>>>> b4ef06f15defe758aee32d064e4d225ce982ce3f
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}