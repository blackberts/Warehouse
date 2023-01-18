using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Tests.AutoData;
using Warehouse.DataContext;

namespace Tests.Database
{
    public class WarehouseDbContextTest
    {
        private DbContextOptions<WarehouseDbContext> _dbContextOptions;
        private readonly WarehouseDbContext _dbContext;

        public WarehouseDbContextTest()
        {
            _dbContextOptions = new DbContextOptionsBuilder<WarehouseDbContext>()
                .UseInMemoryDatabase("WareHouseInMemory")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            _dbContext = new WarehouseDbContext(_dbContextOptions);

            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _dbContext.AddRange(WorkerData.CreateWorkersList());
            _dbContext.AddRange(DepartmentData.CreateDepartmentsList());
            _dbContext.AddRange(ProductData.CreateProductList());

            _dbContext.SaveChanges();
        }

        [Theory]
        [InlineData("0ab00674-97ea-45b1-b7f9-9c5f0b2568d5")]
        [InlineData("66bbc7ef-602a-47f7-a584-a226c8dc5d73")]
        public async Task FindWorkerById_Return_NotNull_Async(string workerId)
        {
            // Act
            var guidId = new Guid(workerId);

            // Arrange
            var entity = await _dbContext.Workers.FirstOrDefaultAsync(x => x.Id.Equals(guidId));

            // Assert
            Assert.NotNull(entity);
        }

        [Fact]
        public async Task GetAllWorkers_Return_NotNull_Async()
        {
            // Act
            var listOfWorkersCheck = WorkerData.CreateWorkersList().ToList();

            // Arrange
            var listOfWorkers = await _dbContext.Workers.ToListAsync();

            // Assert
            Assert.NotNull(listOfWorkers);
            Assert.Equal(listOfWorkersCheck.Count, listOfWorkers.Count);
        }

        [Theory]
        [InlineData("36ad6d8c-cd06-4cda-88f5-d1957b3772a4")]
        [InlineData("93eb5b3d-211e-4dd3-8503-01164ea65a66")]
        public async Task FindDepartmentById_Return_NotNull_Async(string departmentId)
        {
            // Act
            var guidId = new Guid(departmentId);

            // Arrange
            var entity = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id.Equals(guidId));

            // Assert
            Assert.NotNull(entity);
        }

        [Fact]
        public async Task GetAllDepartments_Return_NotNull_Async()
        {
            // Act
            var listOfDepartmentsCheck = DepartmentData.CreateDepartmentsList().ToList();

            // Arrange
            var listOfDepartments = await _dbContext.Departments.ToListAsync();

            // Assert
            Assert.NotNull(listOfDepartments);
            Assert.Equal(listOfDepartmentsCheck.Count, listOfDepartments.Count);
        }

        [Theory]
        [InlineData("45120077-a72a-415a-902f-148d8074fc6a")]
        [InlineData("e47eb715-ca10-4790-a022-da188c80b745")]
        public async Task FindProductById_Return_NotNull_Async(string productId)
        {
            // Act
            var guidId = new Guid(productId);

            // Arrange
            var entity = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id.Equals(guidId));

            // Assert
            Assert.NotNull(entity);
        }

        [Fact]
        public async Task GetAllProducts_Return_NotNull_Async()
        {
            // Act
            var listOfProductsCheck = ProductData.CreateProductList().ToList();

            // Arrange
            var listOfProducts = await _dbContext.Products.ToListAsync();

            // Assert
            Assert.NotNull(listOfProducts);
            Assert.Equal(listOfProductsCheck.Count, listOfProducts.Count);
        }
    }
}
