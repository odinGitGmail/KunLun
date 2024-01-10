using Microsoft.AspNetCore.Mvc;

namespace KunLun.Api.Controllers;
[ApiVersion("2.0")]
[ApiController]
public class VersionTestController : ControllerBase
{
    // [Route("/api/{v:apiVersion}/values")]
    // [HttpGet]
    // public string Version2()
    // {
    //     return "version-test method : 2.0";
    // }
}