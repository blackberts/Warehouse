using Warehouse.DataContext.Repositories.Base;
using Warehouse.Domain.Models;
using WorkerEntity = Warehouse.Domain.Entities.Worker;

namespace Warehouse.DataContext.Repositories.Worker
{
    public interface IWorkerRepository : IRepository<WorkerEntity, WorkerModel>
    {
        Task<List<WorkerModel>> GetAllWithDependenciesAsync();
        Task<WorkerModel> GetByIdAsync(Guid id);
        Task<WorkerModel> CreateWorkerAsync(WorkerEntity worker);
        Task<WorkerModel> UpdateWorkerAsync(WorkerEntity worker);
        Task<WorkerModel> UpdateWorkerFirstNameAsync(WorkerEntity worker);
        Task<WorkerModel> UpdateWorkerLastNameAsync(WorkerEntity worker);
        void DeleteById(Guid id);
    }
}
