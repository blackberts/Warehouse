using Warehouse.DataContext.Repositories.Department;
using Warehouse.DataContext.Repositories.Product;
using Warehouse.DataContext.Repositories.Worker;
using Warehouse.DataContext.Repositories.WorkersDepartments;

namespace Warehouse.Application.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Department { get; }
        IProductRepository Product { get; }
        IWorkerRepository Worker { get; }
        IWorkersDepartmentsRepository WorkersDepartments { get; }
        Task<bool> SaveChangesAsync();
    }
}
