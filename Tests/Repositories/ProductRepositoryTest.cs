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
using Warehouse.DataContext.Repositories.Product;

namespace Tests.Repositories
{
    public class ProductRepositoryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILogger> _loggerMock;
        private readonly IProductRepository _productRepository;
        private readonly DbSet<Product> _DBProduct;
        private readonly WarehouseDbContext _dbContext;
        private DbContextOptions<WarehouseDbContext> _dbContextOptions;

        public ProductRepositoryTest()
        {
            var myProfile = new ProductModelMapping();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
            _loggerMock = new Mock<ILogger>();

            _dbContextOptions = new DbContextOptionsBuilder<WarehouseDbContext>()
                .UseInMemoryDatabase("WareHouseInMemoryForRep")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            _dbContext = new WarehouseDbContext(_dbContextOptions);
            _productRepository = new ProductRepository(_loggerMock.Object, _mapper, _dbContext);
            _DBProduct = _dbContext.Set<Product>();

            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _dbContext.AddRange(ProductData.CreateProductList());

            _dbContext.SaveChanges();
        }

        [Theory]
        [InlineData("45120077-a72a-415a-902f-148d8074fc6a", "Head")]
        [InlineData("e47eb715-ca10-4790-a022-da188c80b745", "Fish")]
        public async Task GetByIdAsync_Return_CorrectModel_Async(string productId, string name)
        {
            // Act
            var guidId = new Guid(productId);

            // Arrange
            var result = await _productRepository.GetByIdAsync(guidId);

            // Assert
            Assert.Equal(name, result.Name);
        }

        [Theory]
        [InlineData("e4111715-ca10-4790-a022-da188c80b745")]
        public async Task GetByIdAsync_Return_InCorrectModel_Null_Async(string productId)
        {
            // Act
            var guidId = new Guid(productId);

            // Arrange
            var result = await _productRepository.GetByIdAsync(guidId);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [AutoProductData]
        public async Task CreateProductAsync_AddEntityInContext_Async(Product entity)
        {
            // Act      
            var result = await _productRepository.CreateProductAsync(entity);
            await _dbContext.SaveChangesAsync();

            // Arrange
            var contextResult = await _productRepository.GetByIdAsync(entity.Id);

            // Assert
            Assert.NotNull(contextResult);
            Assert.Equal(result.Id, contextResult.Id);
        }

        [Fact]
        public async Task GetAll_Return_ListOfProductsModel_Async()
        {
            // Act

            // Arrange
            var listOfWorkers = await _productRepository.GetAllAsync();

            // Assert
            Assert.NotNull(listOfWorkers);
        }
    }
}
