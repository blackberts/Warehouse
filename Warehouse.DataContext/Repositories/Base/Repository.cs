using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Warehouse.DataContext.Repositories.Base
{
    public class Repository<TEntity, TModel> : IRepository<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly WarehouseDbContext DbContext;

        public Repository(ILogger logger,
            IMapper mapper,
            WarehouseDbContext dbContext)
        {
            Logger = logger;
            Mapper = mapper;
            DbSet = dbContext.Set<TEntity>();
            DbContext = dbContext;
        }

        public async Task<List<TModel>> GetAllAsync()
        {
            Logger.LogInformation("Get all objects with name {0}... :", typeof(TEntity).Name);

            var entities = await DbSet.AsNoTracking()
                .ToListAsync();

            var result = Mapper.Map<List<TModel>>(entities);

            return result;
        }
    }
}
