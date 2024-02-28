namespace KunLun.WebApiTest;

public class MyBackgroundService : BackgroundService
{
    private readonly ILogger<MyBackgroundService> _logger;

    public MyBackgroundService(ILogger<MyBackgroundService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("Background task is running.");

            // Your background task logic goes here...

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken); // Example delay
        }
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Background task is StartAsync.");
        return base.StartAsync(cancellationToken);
    }
}