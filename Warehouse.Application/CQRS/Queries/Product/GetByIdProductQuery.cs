using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Product
{
    public class GetByIdProductQuery : IRequest<ProductModel>
    {
        public Guid Id { get; set; }
    }
}
