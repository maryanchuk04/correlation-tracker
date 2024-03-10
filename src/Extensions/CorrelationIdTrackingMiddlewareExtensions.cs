using CorrelationTracking.Contract;
using CorrelationTracking.Middlewares;
using CorrelationTracking.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CorrelationTracking.Extensions
{
    public static class CorrelationIdTrackingMiddlewareExtensions
    {
        public static void AddCorrelationIdTrackingServices(this IServiceCollection services)
        {
            services.AddTransient<IRequestCorrelationReader, CorrelationIdReader>();
            services.AddTransient<IRequestCorrelationWritter, CorrelationIdWriter>();
        }

        public static IApplicationBuilder UseCorrelationIdTrackingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorrelationIdTrackingMiddleware>();
        }
    }
}
