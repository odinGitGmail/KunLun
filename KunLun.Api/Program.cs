using Cola.ColaMiddleware.ColaSwagger;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddColaSwagger(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseColaSwagger("/swagger/v1/swagger.json", "WebApi V1",null);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();