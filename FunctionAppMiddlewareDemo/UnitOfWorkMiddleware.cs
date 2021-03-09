using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker.Pipeline;

namespace FunctionAppMiddlewareDemo
{
    public sealed class UnitOfWorkMiddleware
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkMiddleware(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Invoke(FunctionExecutionContext context, FunctionExecutionDelegate next)
        {
            await next(context);
            await _unitOfWork.CommitAsync();
        }
    }
}
