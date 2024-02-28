using Cola.ColaHostedService.ColaBgJob;
using Cola.ColaMiddleware.ColaSwagger;
using Cola.ColaSignalR;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
// builder.Services.AddControllers();
builder.Services.AddControllers();
// builder.Services.AddColaInjectCore(config);
builder.Services.AddColaSwagger(config);

builder.Services.AddSingleton<ColaBackgroundNormalJob>();
builder.Services.AddColaSignalRHub();
// builder.Services.AddSingleton<MyBackgroundService>();
// builder.Services.AddHostedService<ColaBackgroundNormalJob>();
// builder.Services.AddHostedService<MyBackgroundService>();
// builder.AddColaNacos(config, "ColaNacos", "cola-Development");
// builder.Services.AddColaBgServiceNormalJob(model =>
// {
//     model.StartAsyncAction = token =>
//     {
//         Thread.Sleep(5000);
//         Console.WriteLine("ColaBgServiceNormalJob - StartAsyncAction");
//     };
//     model.StopAsyncAction = token =>
//     {
//         Thread.Sleep(5000);
//         Console.WriteLine("ColaBgServiceNormalJob - StopAsyncAction");
//     };
//     model.DisposeAction = () =>
//     {
//         Thread.Sleep(5000);
//         Console.WriteLine("ColaBgServiceNormalJob - DisposeAction");
//     };
//     model.NormalJobAction = token =>
//     {
//         Thread.Sleep(5000);
//         Console.WriteLine("ColaBgServiceNormalJob - NormalJobAction");
//     };
// });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// app.UseIpRateLimiting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseColaSwagger(new Dictionary<string, string>()
    {
        {"/swagger/v1/swagger.json", "WebApi V1"}
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.UseWebSockets();
// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
//     endpoints.MapHub<ColaSignalR>("/api/cola-signalr");
// });
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
lifetime.ApplicationStarted.Register(() =>
{
    Console.WriteLine("Application started.");
});

lifetime.ApplicationStopping.Register(() =>
{
    Console.WriteLine("Application stopping.");
});

lifetime.ApplicationStopped.Register(() =>
{
    Console.WriteLine("Application stopped.");
});

app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        //添加/注册对应的Hub类,并添加路由
        //请注意：在不同的.Net Core版本中，MapHub方法也可能在app中
        //如果找不到MapHub请两个地方都试一试
        endpoints.MapHub<ColaSignalR>("/api/cola-signalr");
    });
// app.UseCors("lingluAllCors");
app.Run();