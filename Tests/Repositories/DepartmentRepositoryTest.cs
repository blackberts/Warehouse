using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using Tests.Attributes;
using Tests.AutoData;
using Warehouse.Application.Mapping;
using Warehouse.DataContext;
using Warehouse.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Warehouse.DataContext.Repositories.Department;

namespace Tests.Repositories
{
    public class DepartmentRepositoryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILogger> _loggerMock;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly DbSet<Department> _DBDepartment;
        private readonly WarehouseDbContext _dbContext;
        private DbContextOptions<WarehouseDbContext> _dbContextOptions;

        public DepartmentRepositoryTest()
        {
            var myProfile = new DepartmentModelMapping();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
            _loggerMock = new Mock<ILogger>();

            _dbContextOptions = new DbContextOptionsBuilder<WarehouseDbContext>()
                .UseInMemoryDatabase("WareHouseInMemoryForRep")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            _dbContext = new WarehouseDbContext(_dbContextOptions);
            _departmentRepository = new DepartmentRepository(_loggerMock.Object, _mapper, _dbContext);
            _DBDepartment = _dbContext.Set<Department>();

            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _dbContext.AddRange(DepartmentData.CreateDepartmentsList());

            _dbContext.SaveChanges();
        }

        [Theory]
        [InlineData("36ad6d8c-cd06-4cda-88f5-d1957b3772a4")]
        public async Task DeleteByIdDepartment_Return_Null_Async(string departmentId)
        {
            // Act
            _departmentRepository.DeleteById(new Guid(departmentId));
            await _dbContext.SaveChangesAsync();

            // Arrange
            var result = await _departmentRepository.GetByIdAsync(new Guid(departmentId));

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData("36ad6d8c-cd06-4cda-88f5-d1957b3772a4", "Test")]
        [InlineData("93eb5b3d-211e-4dd3-8503-01164ea65a66", "Features")]
        public async Task GetByIdAsync_Return_CorrectModel_Async(string departmentId, string name)
        {
            // Act
            var guidId = new Guid(departmentId);

            // Arrange
            var result = await _departmentRepository.GetByIdAsync(guidId);

            // Assert
            Assert.Equal(name, result.Name);
        }

        [Theory]
        [InlineData("31116d8c-cd06-4cda-88f5-d1957b3772a4")]
        public async Task GetByIdAsync_Return_InCorrectModel_Null_Async(string departmentId)
        {
            // Act
            var guidId = new Guid(departmentId);

            // Arrange
            var result = await _departmentRepository.GetByIdAsync(guidId);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [AutoDepartmentData]
        public async Task CreateDepartmentAsync_AddEntityInContext_Async(Department entity)
        {
            // Act      
            var result = await _departmentRepository.CreateDepartmentAsync(entity);
            await _dbContext.SaveChangesAsync();

            // Arrange
            var contextResult = await _departmentRepository.GetByIdAsync(entity.Id);

            // Assert
            Assert.NotNull(contextResult);
            Assert.Equal(result.Id, contextResult.Id);
        }       

        [Fact]
        public async Task GetAll_Return_ListOfDepartmentsModel_Async()
        {
            // Act

            // Arrange
            var listOfWorkers = await _departmentRepository.GetAllAsync();

            // Assert
            Assert.NotNull(listOfWorkers);
        }
    }
}
