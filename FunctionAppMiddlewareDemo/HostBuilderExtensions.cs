using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionAppMiddlewareDemo
{
    public static class HostBuilderExtensions
    {
        internal static IFunctionsWorkerApplicationBuilder UseLoggingMiddleware(this IFunctionsWorkerApplicationBuilder builder)
        {
            builder.Services.AddSingleton<LoggingMiddleware>();

            builder.Use(next =>
            {
                return context =>
                {
                    var middleware = context.InstanceServices.GetRequiredService<LoggingMiddleware>();

                    return middleware.Invoke(context, next);
                };
            });

            return builder;
        }

        internal static IFunctionsWorkerApplicationBuilder UseUnitOfWorkMiddleware(this IFunctionsWorkerApplicationBuilder builder)
        {
            builder.Services.AddSingleton<UnitOfWorkMiddleware>();

            builder.Use(next =>
            {
                return context =>
                {
                    var middleware = context.InstanceServices.GetRequiredService<UnitOfWorkMiddleware>();

                    return middleware.Invoke(context, next);
                };
            });

            return builder;
        }
    }
}
