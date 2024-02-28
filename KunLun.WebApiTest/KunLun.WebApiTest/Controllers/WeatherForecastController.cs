using Cola.ColaHostedService.ColaBgJob;
using Cola.ColaSignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace KunLun.WebApiTest.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string v = $"{DateTime.Now:yyyy-MM-dd hh:mm:ss zz}";
    private readonly ColaBackgroundNormalJob _colaBackgroundNormalJob;
    private readonly IHubContext<ColaSignalR> _colaSignalRHub;
    public WeatherForecastController(
        ColaBackgroundNormalJob colaBackgroundNormalJob,
        IHubContext<ColaSignalR> colaSignalRHub)
    {
        _colaBackgroundNormalJob = colaBackgroundNormalJob;
        _colaSignalRHub = colaSignalRHub;
        InitJob();
    }

    void InitJob()
    {
        _colaBackgroundNormalJob.NormalJobWorkerFuncAsync = async cancellationToken =>
        {
            Console.WriteLine("NormalJobWorkerFuncAsync");
            for (int i = 0; i < 2; i++)
            {
                await _colaSignalRHub.Clients.All.SendAsync("SendMessageAsync", $"WeatherForecastController {v}", cancellationToken: cancellationToken);
                await Task.Delay(3000, cancellationToken);
            }
        };
    }
    
    [HttpGet("start")]
    public Task<IActionResult> StartBackgroundService()
    {
        // 启动后台服务
        Task.Run(async () =>
        {
            await _colaBackgroundNormalJob.StartAsync(default);
        });
        return Task.FromResult<IActionResult>(Ok("Background service started."));
    }

    [HttpGet("stop")]
    public Task<IActionResult> StopBackgroundService()
    {
        // 停止后台服务
        return Task.FromResult<IActionResult>(Ok("Background service stopped."));
    }
}