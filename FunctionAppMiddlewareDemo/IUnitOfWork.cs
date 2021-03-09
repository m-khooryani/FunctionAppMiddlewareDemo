using System.Threading.Tasks;

namespace FunctionAppMiddlewareDemo
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }

    public class EfUnitOfWork : IUnitOfWork
    {
        public async Task CommitAsync()
        {
            await Task.CompletedTask;
        }
    }
}
