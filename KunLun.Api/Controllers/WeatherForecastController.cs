using Microsoft.AspNetCore.Mvc;

namespace KunLun.Api.Controllers;

[ApiVersion("1.0")]
[ApiController]
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

    /// <summary>
    /// Version1
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/values")]
    public string Version()
    {
        return "version-test method : 1.0";
    }
    
    /// <summary>
    /// Version2
    /// </summary>
    /// <returns></returns>
    [ApiVersion("2.0")]
    [HttpGet("/api/{v:apiVersion}/values")]
    public string Version2()
    {
        return "version-test method : 2.0";
    }
}