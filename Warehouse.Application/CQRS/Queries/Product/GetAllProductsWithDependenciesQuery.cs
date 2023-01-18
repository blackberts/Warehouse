using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Product
{
    public class GetAllProductsWithDependenciesQuery : IRequest<List<ProductModel>>
    {
    }
}
