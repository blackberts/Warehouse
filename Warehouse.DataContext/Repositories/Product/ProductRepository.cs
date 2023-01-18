using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Warehouse.DataContext.Repositories.Base;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Models;
using ProductEntity = Warehouse.Domain.Entities.Product;

namespace Warehouse.DataContext.Repositories.Product
{
    public class ProductRepository : Repository<ProductEntity, ProductModel>, IProductRepository
    {
        public ProductRepository(ILogger logger,
            IMapper mapper,
            WarehouseDbContext dbContext) : base(logger, mapper, dbContext)
        {
        }

        public async Task<ProductModel> CreateProductAsync(ProductEntity product)
        {
            Logger.LogInformation("Creating new product with id... {0}", product.Id);

            await DbSet.AddAsync(product);

            var result = Mapper.Map<ProductModel>(product);

            return result;
        }

        public void DeleteById(Guid productId)
        {
            Logger.LogInformation("Delete product with id... {0}", productId);

            var id = new SqlParameter("@ProductId", productId);

            DbContext.Database.ExecuteSqlRaw("DELETE FROM Products " +
               "WHERE ProductId = @ProductId ", id);
        }

        public async Task<ProductModel> GetByIdAsync(Guid id)
        {
            Logger.LogInformation("Finding product with id... : {0} ", id);

            var entity = await DbSet.AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id
                .Equals(id));

            var result = Mapper.Map<ProductModel>(entity);

            return result;
        }

        public void CreateDependencies(ProductEntity product)
        {
            Logger.LogInformation($"Creating dependencies between product: {product.Id} and department: {product.DeparmentId}");

            DbSet.Update(product);
        }

        public async Task<ProductModel> UpdateProductAsync(ProductEntity product)
        {
            Logger.LogInformation("Updating product with id... : {0}", product.Id);

            DbSet.Update(product);

            var result = Mapper.Map<ProductModel>(product);

            return result;
        }

        public async Task<List<ProductModel>> GetAllWithDependenciesAsync()
        {
            Logger.LogInformation("Get all products with dependencies... ");

            var entities = await DbSet.AsNoTracking()
                .Include(product => product.Department)
                .Select(product => new ProductEntity
                {
                    Id = product.Id,
                    Name = product.Name,
                    Department = product.Department,
                })
                .ToListAsync();

            var result = Mapper.Map<List<ProductModel>>(entities);

            return result;
        }
    }
}
