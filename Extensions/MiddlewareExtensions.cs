using ContosoPizza.Middlewares;

namespace ContosoPizza.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseRateLimiting(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RateLimitingMiddleware>();
    }
}