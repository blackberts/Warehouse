using AutoMapper;
using Microsoft.Extensions.Logging;
using Warehouse.DataContext;
using Warehouse.DataContext.Repositories.Department;
using Warehouse.DataContext.Repositories.Product;
using Warehouse.DataContext.Repositories.Worker;
using Warehouse.DataContext.Repositories.WorkersDepartments;

namespace Warehouse.Application.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private ILogger _logger;
        private IMapper _mapper;
        private WarehouseDbContext _dbContext;

        public UnitOfWork(ILogger logger,
            IMapper mapper,
            WarehouseDbContext dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        private IDepartmentRepository _departmentRepository;
        public IDepartmentRepository Department
        {
            get
            {
                return _departmentRepository ??= new DepartmentRepository(_logger, _mapper, _dbContext);
            }
        }

        private IProductRepository _productRepository;
        public IProductRepository Product
        {
            get
            {
                return _productRepository ??= new ProductRepository(_logger, _mapper, _dbContext);
            }
        }

        private IWorkerRepository _workerRepository;
        public IWorkerRepository Worker
        {
            get
            {
                return _workerRepository ??= new WorkerRepository(_logger, _mapper, _dbContext);
            }
        }

        private IWorkersDepartmentsRepository _workersDepartmentsRepository;
        public IWorkersDepartmentsRepository WorkersDepartments
        {
            get
            {
                return _workersDepartmentsRepository ??= new WorkersDepartmentsRepository(_logger, _mapper, _dbContext);
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
