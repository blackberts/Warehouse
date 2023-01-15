using Warehouse.DataContext.Repositories.Base;
using Warehouse.Domain.Models;
using WorkersDepartmentsEntity = Warehouse.Domain.Entities.WorkersDepartments;

namespace Warehouse.DataContext.Repositories.WorkersDepartments
{
    public interface IWorkersDepartmentsRepository : IRepository<WorkersDepartmentsEntity, WorkersDepartmentsModel>
    {
        void CreateDependencies(WorkersDepartmentsEntity wd);
    }
}
