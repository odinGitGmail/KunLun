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
        string str = "abc123abc456abc";
        str = str.Replace("a", string.Empty);
        return $"1.0 {str}";
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