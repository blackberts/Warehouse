using Warehouse.DataContext.Repositories.Base;
using Warehouse.Domain.Models;
using WorkersDepartmentsEntity = Warehouse.Domain.Entities.WorkersDepartments;

namespace Warehouse.DataContext.Repositories.WorkersDepartments
{
    public interface IWorkersDepartmentsRepository : IRepository<WorkersDepartmentsEntity, WorkersDepartmentsModel>
    {
        Task<List<WorkersDepartmentsModel>> GetAllWorkersWithDependenciesAsync();
        Task<List<WorkersDepartmentsModel>> GetAllDepartmentsWithDependenciesAsync();
        void CreateDependencies(WorkersDepartmentsEntity wd);
        void DeleteByIdDepartment(Guid id);
        void DeleteByIdWorker(Guid id);
    }
}
