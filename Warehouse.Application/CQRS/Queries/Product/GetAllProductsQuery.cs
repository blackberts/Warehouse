using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Product
{
    public class GetAllProductsQuery : IRequest<List<ProductModel>>
    {
    }
}
