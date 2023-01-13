using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Commands.Department
{
    public class UpdateDepartmentCommand : IRequest<DepartmentModel>
    {
        public string Name { get; set; }
    }
}
