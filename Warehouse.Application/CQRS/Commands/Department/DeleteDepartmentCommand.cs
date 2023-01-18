using MediatR;

namespace Warehouse.Application.CQRS.Commands.Department
{
    public class DeleteDepartmentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
