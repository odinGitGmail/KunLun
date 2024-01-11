using AspNetCoreRateLimit;
using Cola.ColaMiddleware.ColaIpRateLimit;
using Cola.ColaMiddleware.ColaSwagger;
using Cola.ColaMiddleware.ColaVersioning;
using Microsoft.AspNetCore.Hosting;
using Cola.SystemBuilder;
using Cola.ColaJwt;

var builder = WebApplication.CreateBuilder(args);
builder.Host
    .ConfigureLogging((hostingContext, builder) =>
    {
        //该方法需要引入Microsoft.Extensions.Logging名称空间
        builder.AddFilter("System", LogLevel.Error); //过滤掉系统默认的一些日志
        builder.AddFilter("Microsoft", LogLevel.Error); //过滤掉系统默认的一些日志
    });

builder.Configuration.AddJsonFile("appsettings.json");
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddColaJwt(config);
builder.Services.AddColaVersioning(config);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddColaSwagger(config);
builder.Services.AddColaIpRateLimit(config);
builder.Services.AddColaCors(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // app.UseSwaggerUI();
    app.UseColaSwagger(new Dictionary<string, string>()
    {
        {"/swagger/v1/swagger.json", "WebApi V1"},
        {"/swagger/v2/swagger.json", "WebApi V2"}
    });
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("LimitRequests");
app.UseIpRateLimiting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();