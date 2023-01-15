using MediatR;

namespace Warehouse.Application.CQRS.Commands.Product
{
    public class AssignDepartmentToProductCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
