using MediatR;

namespace Warehouse.Application.CQRS.Commands.Department
{
    public class AssignProductsToDepartmentCommand : IRequest
    {
        public Guid DepartmentId { get; set; }
        public List<Guid> ProductIds { get; set; }
    }
}
