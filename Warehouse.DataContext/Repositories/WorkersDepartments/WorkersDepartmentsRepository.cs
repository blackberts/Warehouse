using AutoMapper;
using Microsoft.Extensions.Logging;
using Warehouse.DataContext.Repositories.Base;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Models;
using WorkersDepartmentsEntity = Warehouse.Domain.Entities.WorkersDepartments;

namespace Warehouse.DataContext.Repositories.WorkersDepartments
{
    public class WorkersDepartmentsRepository : Repository<WorkersDepartmentsEntity, WorkersDepartmentsModel>, IWorkersDepartmentsRepository
    {
        public WorkersDepartmentsRepository(ILogger logger,
            IMapper mapper,
            WarehouseDbContext dbContext) : base(logger, mapper, dbContext)
        {
        }

        public void CreateDependencies(WorkersDepartmentsEntity wd)
        {
            Logger.LogInformation($"Creating dependencies between worker: {wd.WorkerId} and department: {wd.DepartmentId}");

            DbSet.Add(wd);
        }
    }
}
