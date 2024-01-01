using H12Auth2C.Middlewares;

namespace H12Auth2C.Extensions
{
    public static class RequestLocalizationCookiesMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLocalizationCookies(this IApplicationBuilder app)
           => app.UseMiddleware<RequestLocalizationCookiesMiddleware>();
    }
}
