using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Pipeline;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace FunctionAppMiddlewareDemo
{
    public static class SomeCommandFunction
    {
        [FunctionName(nameof(SomeCommandFunction))]
        public static Guid Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")]
            HttpRequestData req, FunctionExecutionContext executionContext)
        {
            // some Logic (skipped for simplicity)
            var addedId = Guid.NewGuid();
            return addedId;
        }
    }
}
