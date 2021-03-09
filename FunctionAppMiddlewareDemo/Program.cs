using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FunctionAppMiddlewareDemo
{
    class Program
    {
        static Task Main(string[] args)
        {
#if DEBUG
            Debugger.Launch();
#endif
            var host = new HostBuilder()
                .ConfigureAppConfiguration(configurationBuilder =>
                {
                    configurationBuilder.AddCommandLine(args);
                })
                .ConfigureFunctionsWorker((hostBuilderContext, workerApplicationBuilder) =>
                {
                    workerApplicationBuilder.UseLoggingMiddleware();
                    workerApplicationBuilder.UseUnitOfWorkMiddleware();
                    workerApplicationBuilder.UseFunctionExecutionMiddleware();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<ILoggerFactory, LoggerFactory>();
                    services.AddScoped<IUnitOfWork, EfUnitOfWork>();
                    services.AddHttpClient();
                })
                .Build();

            return host.RunAsync();
        }
    }
}
