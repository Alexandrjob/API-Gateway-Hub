using JwtIdentity.Models.Interfaces;
using JwtIdentity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JwtIdentity;

public static class IdentityHostBuilderExtensions
{
    public static IHostBuilder AddJwtIdentity(this IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddScoped<JwtTokenService>();
            services.AddScoped<IPasswordHasher<IIdentityUser>, PasswordHasher<IIdentityUser>>();
            services.AddScoped<PasswordManager>();
        });

        return builder;
    }
}