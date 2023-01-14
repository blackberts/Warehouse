using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Warehouse.DataContext.Repositories.Base;
using Warehouse.Domain.Models;
using WorkerEntity = Warehouse.Domain.Entities.Worker;

namespace Warehouse.DataContext.Repositories.Worker
{
    public class WorkerRepository : Repository<WorkerEntity, WorkerModel>, IWorkerRepository
    {
        public WorkerRepository(ILogger logger,
            IMapper mapper,
            WarehouseDbContext dbContext) : base(logger, mapper, dbContext)
        {
        }

        public async Task<WorkerModel> CreateWorkerAsync(WorkerEntity worker)
        {
            Logger.LogInformation("Creating new worker with id... {0}", worker.Id);

            await DbSet.AddAsync(worker);

            var result = Mapper.Map<WorkerModel>(worker);

            return result;
        }

        public void DeleteById(Guid id)
        {
            Logger.LogInformation("Delete worker with id... {0}", id);

            var entity = DbSet.Find(id);

            DbSet.Remove(entity);
        }

        public async Task<WorkerModel> GetByIdAsync(Guid id)
        {
            Logger.LogInformation("Finding worker with id... : {0} ", id);

            var entity = await DbSet.AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id
                .Equals(id));

            var result = Mapper.Map<WorkerModel>(entity);

            return result;
        }

        public async Task<WorkerModel> UpdateWorkerAsync(WorkerEntity worker)
        {
            Logger.LogInformation("Updating worker with id... : {0}", worker.Id);

            DbSet.Update(worker);

            var result = Mapper.Map<WorkerModel>(worker);

            return result;
        }
    }
}
