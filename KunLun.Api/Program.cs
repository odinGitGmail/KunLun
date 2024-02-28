using AspNetCoreRateLimit;
using Cola.ColaInject;
using Cola.ColaJwt;
using Cola.ColaMiddleware.ColaSwagger;
using Cola.ColaMiddleware.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
builder.Host
    .ConfigureLogging((hostingContext, build) =>
    {
        //该方法需要引入Microsoft.Extensions.Logging名称空间
        build.AddFilter("System", LogLevel.Error); //过滤掉系统默认的一些日志
        build.AddFilter("Microsoft", LogLevel.Error); //过滤掉系统默认的一些日志
    });

builder.Configuration.AddJsonFile("appsettings.json");
var config = builder.Configuration;
// HttpContext注入
builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddColaCore(config);
builder.Services.AddControllers();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAccessToken", policy =>
        policy.Requirements.Add(new RefreshTokenRequirement(300))); // Set refresh threshold (e.g., 300 seconds)
});
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
app.UseCors();
app.UseIpRateLimiting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseColaHealthChecks("/healthCheck");
app.Run();