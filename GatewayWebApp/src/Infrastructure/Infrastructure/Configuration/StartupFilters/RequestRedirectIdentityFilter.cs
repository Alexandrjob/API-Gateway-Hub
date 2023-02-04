using Infrastructure.Configuration.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure.Configuration.StartupFilters;

public class RequestRedirectIdentityFilter : IStartupFilter
{
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        return app =>
        {
            app.UseMiddleware<RequestRedirectIdentityMiddleware>("http://localhost:5000");
            next(app);
        };
    }
}