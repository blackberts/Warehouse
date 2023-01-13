using Warehouse.DataContext.Repositories.Department;

namespace Warehouse.Application.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Department { get; }
        Task<bool> SaveChangesAsync();
    }
}
