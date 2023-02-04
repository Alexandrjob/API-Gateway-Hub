using Infrastructure;
using JwtIdentity;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddJwtIdentity();
builder.Host.AddInfrastructure();

var app = builder.Build();

app.MapControllers();

app.Run();