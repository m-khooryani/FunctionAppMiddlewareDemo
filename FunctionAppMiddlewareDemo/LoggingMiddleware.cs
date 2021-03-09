using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker.Pipeline;
using Microsoft.Extensions.Logging;

namespace FunctionAppMiddlewareDemo
{
    public sealed class LoggingMiddleware
    {
        private readonly ILogger _logger;

        public LoggingMiddleware(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("someLogger");
        }

        public async Task Invoke(FunctionExecutionContext context, FunctionExecutionDelegate next)
        {
            var funcName = context.FunctionDefinition.Metadata.FuncName;

            _logger.LogInformation($"{funcName} started");
            await next(context);
            _logger.LogInformation($"{funcName} finished");
        }
    }
}
