using Warehouse.DataContext.Repositories.Base;
using DepartmentEntity = Warehouse.Domain.Entities.Department;
using DepartmentModel = Warehouse.Domain.Models.DepartmentModel;

namespace Warehouse.DataContext.Repositories.Department
{
    public interface IDepartmentRepository : IRepository<DepartmentEntity, DepartmentModel>
    {
        Task<DepartmentModel> GetByIdAsync(Guid id);
        Task<DepartmentModel> CreateDepartmentAsync(DepartmentEntity department);
        Task<DepartmentModel> UpdateDepartmentAsync(DepartmentEntity department);
        void DeleteById(Guid id);
    }
}
