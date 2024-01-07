<<<<<<< HEAD
using Cola.ColaMiddleware.ColaSwagger;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
=======
var builder = WebApplication.CreateBuilder(args);

>>>>>>> b4ef06f15defe758aee32d064e4d225ce982ce3f
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
<<<<<<< HEAD
builder.Services.AddColaSwagger(config);
=======
builder.Services.AddSwaggerGen();
>>>>>>> b4ef06f15defe758aee32d064e4d225ce982ce3f

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
<<<<<<< HEAD
    app.UseColaSwagger("/swagger/v1/swagger.json", "WebApi V1",null);
=======
    app.UseSwagger();
    app.UseSwaggerUI();
>>>>>>> b4ef06f15defe758aee32d064e4d225ce982ce3f
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();