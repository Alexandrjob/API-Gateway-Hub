using Infrastructure;
using JwtIdentity;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddInfrastructure();
builder.Host.AddJwtIdentity();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(b =>
    {
        b.WithOrigins("http://localhost:5266")
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(b =>
    b.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.MapControllers();

app.Run();