using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tests.Attributes;
using Tests.AutoData;
using Warehouse.Application.Mapping;
using Warehouse.DataContext.Repositories.Worker;
using Warehouse.DataContext;
using Warehouse.Domain.Entities;
using Moq;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace Tests.Repositories
{
    public class WorkerRepositoryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILogger> _loggerMock;
        private readonly IWorkerRepository _workerRepository;
        private readonly DbSet<Worker> _DBWorker;
        private readonly WarehouseDbContext _dbContext;
        private DbContextOptions<WarehouseDbContext> _dbContextOptions;

        public WorkerRepositoryTest()
        {
            var myProfile = new WorkerModelMapping();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
            _loggerMock = new Mock<ILogger>();

            _dbContextOptions = new DbContextOptionsBuilder<WarehouseDbContext>()
                .UseInMemoryDatabase("WareHouseInMemoryForRep")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            _dbContext = new WarehouseDbContext(_dbContextOptions);
            _workerRepository = new WorkerRepository(_loggerMock.Object, _mapper, _dbContext);
            _DBWorker = _dbContext.Set<Worker>();

            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _dbContext.AddRange(WorkerData.CreateWorkersList());

            _dbContext.SaveChanges();
        }

        [Theory]
        [InlineData("66bbc7ef-602a-47f7-a584-a226c8dc5d73", "Arina")]
        public async Task GetByIdAsync_Return_CorrectModel_Async(string workerId, string firstName)
        {
            // Act
            var guidId = new Guid(workerId);

            var workerForMapper = WorkerData.CreateWorkersList()
                .FirstOrDefault(x => x.Id
                .Equals(guidId));

            // Arrange
            var result = await _workerRepository.GetByIdAsync(guidId);

            // Assert
            Assert.Equal(firstName, result.FirstName);
        }

        [Theory]
        [InlineData("01110674-97ea-45b1-b7f9-9c5f0b2568d5")]
        public async Task GetByIdAsync_Return_InCorrectModel_Null_Async(string workerId)
        {
            // Act
            var guidId = new Guid(workerId);

            // Arrange
            var result = await _workerRepository.GetByIdAsync(guidId);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [AutoWorkerData]
        public async Task CreateWorkerAsync_AddEntityInContext_Async(Worker entity)
        {
            // Act      
            var result = await _workerRepository.CreateWorkerAsync(entity);
            await _dbContext.SaveChangesAsync();

            // Arrange
            var contextResult = await _workerRepository.GetByIdAsync(entity.Id);

            // Assert
            Assert.NotNull(contextResult);
            Assert.Equal(result.Id, contextResult.Id);
        }

        [Theory]
        [InlineData("66bbc7ef-602a-47f7-a584-a226c8dc5d73")]
        public async Task DeleteByIdWorker_Return_Null_Async(string workerId)
        {
            // Act
            var guidId = new Guid(workerId);
            _workerRepository.DeleteById(guidId);
            await _dbContext.SaveChangesAsync();

            // Arrange
            var result = await _workerRepository.GetByIdAsync(guidId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAll_Return_ListOfWorkersModel_Async()
        {
            // Act

            // Arrange
            var listOfWorkers = await _workerRepository.GetAllAsync();

            // Assert
            Assert.NotNull(listOfWorkers);
        }
    }
}
