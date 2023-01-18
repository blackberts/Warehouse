using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Commands.Product
{
    public class UpdateProductCommand : IRequest<ProductModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
