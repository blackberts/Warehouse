using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public void DeleteByIdDepartment(Guid id)
        {
            Logger.LogInformation("Delete department with id... {0}", id);

            var entity = DbSet.Find(id);

            DbSet.Remove(entity);
        }

        public void DeleteByIdWorker(Guid id)
        {
            Logger.LogInformation("Delete worker with id... {0}", id);

            var entity = DbSet.Find(id);

            DbSet.Remove(entity);
        }

        public async Task<List<WorkersDepartmentsModel>> GetAllDepartmentsWithDependenciesAsync()
        {
            Logger.LogInformation("Get all departments with dependencies... ");

            var entities = await DbSet.AsNoTracking()
                .Include(wd => wd.Department)
                    .ThenInclude(department => department.Products)
                .Include(wd => wd.Worker)
                .Select(wd => new WorkersDepartmentsEntity
                {
                    DepartmentId = wd.DepartmentId,
                    Department = wd.Department,
                    Worker = wd.Worker,
                })
                .ToListAsync();

            var result = Mapper.Map<List<WorkersDepartmentsModel>>(entities);

            return result;
        }

        public async Task<List<WorkersDepartmentsModel>> GetAllWorkersWithDependenciesAsync()
        {
            Logger.LogInformation("Get all workers with dependencies... ");

            var entities = await DbSet.AsNoTracking()
                .Include(wd => wd.Worker)
                .Include(wd => wd.Department)
                    .ThenInclude(department => department.Products)
                .Select(wd => new WorkersDepartmentsEntity
                {
                    WorkerId = wd.WorkerId,
                    Worker = wd.Worker,
                    Department = wd.Department,
                }) 
                .ToListAsync();

            var result = Mapper.Map<List<WorkersDepartmentsModel>>(entities);

            return result;
        }
    }
}
