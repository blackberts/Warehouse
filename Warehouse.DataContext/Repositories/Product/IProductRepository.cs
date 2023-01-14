using Warehouse.DataContext.Repositories.Base;
using Warehouse.Domain.Models;
using ProductEntity = Warehouse.Domain.Entities.Product;

namespace Warehouse.DataContext.Repositories.Product
{
    public interface IProductRepository : IRepository<ProductEntity, ProductModel>
    {
        Task<ProductModel> GetByIdAsync(Guid id);
        Task<ProductModel> CreateProductAsync(ProductEntity product);
        Task<ProductModel> UpdateProductAsync(ProductEntity product);
        void DeleteById(Guid id);
    }
}
