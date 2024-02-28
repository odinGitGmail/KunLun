using Cola.ColaJwt;
using Cola.Core.Models;
using Cola.Core.Models.ColaJwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetTaste;

namespace KunLun.Api.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Authorize]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IColaJwt _colaJwt;

    public WeatherForecastController(IColaJwt colaJwt)
    {
        _colaJwt = colaJwt;
    }
    
    /// <summary>
    /// login
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/[Controller]/login")]
    [AllowAnonymous]
    public ApiResult<AccessToken> Login()
    {
        return new ApiResult<AccessToken>()
        {
            Data = new AccessToken()
            {
                Token = _colaJwt.GenerateToken("odinSam")
            }
        };
    }

    /// <summary>
    /// Version1
    /// </summary>
    /// <returns></returns>
    [HttpGet("/api/[Controller]/values1")]
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
    [AllowAnonymous]
    [HttpGet("/api/[Controller]/values2")]
    public string Version2()
    {
        return "version-test method : 2.0";
    }
}