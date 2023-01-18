using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Commands.Product
{
    public class CreateProductCommand : IRequest<ProductModel>
    {
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
