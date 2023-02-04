using System.Net.Http.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Configuration.Middlewares;

public class RequestRedirectIdentityMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _targetUri;

    public RequestRedirectIdentityMiddleware(RequestDelegate next, string targetUri)
    {
        _next = next;
        _targetUri = targetUri;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Method == HttpMethods.Post && context.Request.Path.StartsWithSegments("/api/identity"))
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