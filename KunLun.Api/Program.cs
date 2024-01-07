using AspNetCoreRateLimit;
using Cola.ColaMiddleware.ColaIpRateLimit;
using Cola.ColaMiddleware.ColaSwagger;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddColaSwagger(config);
builder.Services.AddSingletonColaIpRateLimit(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
    app.UseColaSwagger("/swagger/v1/swagger.json", "WebApi V1",null);
}



app.UseHttpsRedirection();

app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers();

app.Run();