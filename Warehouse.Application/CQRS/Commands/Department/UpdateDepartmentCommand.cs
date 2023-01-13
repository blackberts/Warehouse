using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Commands.Department
{
    public class UpdateDepartmentCommand : IRequest<DepartmentModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
