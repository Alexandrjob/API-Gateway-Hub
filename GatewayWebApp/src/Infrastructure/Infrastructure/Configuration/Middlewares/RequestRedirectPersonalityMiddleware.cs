using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Configuration.Middlewares;

[Authorize]
public class RequestRedirectPersonalityMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _targetUri;

    public RequestRedirectPersonalityMiddleware(RequestDelegate next, string targetUri)
    {
        _next = next;
        _targetUri = targetUri;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        var use = context.User;
        if(!context.User.Identity.IsAuthenticated)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return;
        }
        
        if (context.Request.Method == HttpMethods.Post && context.Request.Path.StartsWithSegments("/api/personality"))
        {
            var targetUri = new Uri(_targetUri + context.Request.Path);

            using var client = new HttpClient();
            var content = new StreamContent(context.Request.Body);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            var response = await client.PostAsync(targetUri, content);

            context.Response.StatusCode = (int)response.StatusCode;

            var responseStream = await response.Content.ReadAsStreamAsync();
            await responseStream.CopyToAsync(context.Response.Body);
        }
        else
        {
            await _next(context);
        }
    }
}