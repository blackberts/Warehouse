using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Warehouse.DataContext.Repositories.Base;
using DepartmentEntity = Warehouse.Domain.Entities.Department;
using DepartmentModel = Warehouse.Domain.Models.DepartmentModel;

namespace Warehouse.DataContext.Repositories.Department
{
    public class DepartmentRepository : Repository<DepartmentEntity, DepartmentModel>, IDepartmentRepository
    {
        public DepartmentRepository(ILogger logger,
            IMapper mapper,
            WarehouseDbContext dbContext) : base(logger, mapper, dbContext) { }

        public async Task<DepartmentModel> CreateDepartmentAsync(DepartmentEntity department)
        {
            Logger.LogInformation("Creating new department with id... {0}", department.Id);

            await DbSet.AddAsync(department);

            var result = Mapper.Map<DepartmentModel>(department);

            return result;
        }

        public void DeleteById(Guid id)
        {
            Logger.LogInformation("Delete department with id... {0}", id);

            var entity = DbSet.Find(id);

            DbSet.Remove(entity);
        }

        public async Task<DepartmentModel> GetByIdAsync(Guid id)
        {
            Logger.LogInformation("Finding department with id... : {0} ", id);

            var entity = await DbSet.AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id
                .Equals(id));

            var result = Mapper.Map<DepartmentModel>(entity);

            return result;
        }

        public async Task<DepartmentModel> UpdateDepartmentAsync(DepartmentEntity department)
        {
            DbSet.Update(department);

            var result = Mapper.Map<DepartmentModel>(department);

            return result;
        }
    }
}
