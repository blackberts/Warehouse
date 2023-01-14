using AutoMapper;
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

        public void DeleteById(Guid id)
        {
            Logger.LogInformation("Delete product with id... {0}", id);

            var entity = DbSet.Find(id);

            DbSet.Remove(entity);
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

        public async Task<ProductModel> UpdateProductAsync(ProductEntity product)
        {
            Logger.LogInformation("Updating product with id... : {0}", product.Id);

            DbSet.Update(product);

            var result = Mapper.Map<ProductModel>(product);

            return result;
        }
    }
}
