using MediatR;

namespace Warehouse.Application.CQRS.Commands.Worker
{
    public class AssignDepartmentsToWorkerCommand : IRequest
    {
        public Guid WorkerId { get; set; }
        public List<Guid> DepartmentIds { get; set; }
    }
}
