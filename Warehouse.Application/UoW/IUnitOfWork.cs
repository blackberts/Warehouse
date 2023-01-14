using Warehouse.DataContext.Repositories.Department;
using Warehouse.DataContext.Repositories.Product;
using Warehouse.DataContext.Repositories.Worker;

namespace Warehouse.Application.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Department { get; }
        IProductRepository Product { get; }
        IWorkerRepository Worker { get; }
        Task<bool> SaveChangesAsync();
    }
}
