using MediatR;

namespace Warehouse.Application.CQRS.Commands.Department
{
    public class AssignWorkersToDepartmentCommand : IRequest
    {
        public Guid DepartmentId { get; set; }
        public List<Guid> WorkerIds { get; set; }
    }
}
