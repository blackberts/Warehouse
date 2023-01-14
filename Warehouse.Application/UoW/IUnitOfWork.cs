using Warehouse.DataContext.Repositories.Department;
using Warehouse.DataContext.Repositories.Product;

namespace Warehouse.Application.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Department { get; }
        IProductRepository Product { get; }
        Task<bool> SaveChangesAsync();
    }
}
