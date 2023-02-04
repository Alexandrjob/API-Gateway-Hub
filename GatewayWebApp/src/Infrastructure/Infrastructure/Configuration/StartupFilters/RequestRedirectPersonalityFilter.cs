using Infrastructure.Configuration.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure.Configuration.StartupFilters;

public class RequestRedirectPersonalityFilter : IStartupFilter
{
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        return app =>
        {
            app.UseMiddleware<RequestRedirectPersonalityMiddleware>("http://localhost:5213");
            next(app);
        };
    }
}