using AutoMapper;
using Microsoft.Extensions.Logging;
using Warehouse.DataContext;
using Warehouse.DataContext.Repositories.Department;

namespace Warehouse.Application.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private ILogger _logger;
        private IMapper _mapper;
        private WarehouseDbContext _dbContext;
        private IDepartmentRepository _departmentRepository;

        public UnitOfWork(ILogger logger,
            IMapper mapper,
            WarehouseDbContext dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }


        public IDepartmentRepository Department
        {
            get
            {
                return _departmentRepository ??= new DepartmentRepository(_logger, _mapper, _dbContext);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
