using HVACTopGun.DataAccess.Features.ApiKeys;
using System.Net;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IApiKeyRepository _apiKeyRepository;

    public ApiKeyMiddleware(RequestDelegate next, IApiKeyRepository apiKeyRepository)
    {
        _next = next;
        _apiKeyRepository = apiKeyRepository;
    }

    public async Task Invoke(HttpContext context)
    {
        var apiKey = context.Request.Headers["ApiKey"].FirstOrDefault();

        if (string.IsNullOrEmpty(apiKey))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            await context.Response.WriteAsync("Missing API Key");
            return;
        }

        if (!await _apiKeyRepository.IsValidApiKeyAsync(apiKey))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            await context.Response.WriteAsync("Invalid API Key");
            return;
        }

        await _next.Invoke(context);
    }
}