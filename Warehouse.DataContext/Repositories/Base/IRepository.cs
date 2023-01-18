namespace Warehouse.DataContext.Repositories.Base
{
    public interface IRepository<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        Task<List<TModel>> GetAllAsync();
    }
}
