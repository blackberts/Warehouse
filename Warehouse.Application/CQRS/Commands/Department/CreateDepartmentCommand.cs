using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Commands.Department
{
    public class CreateDepartmentCommand : IRequest<DepartmentModel>
    {
        public string Name { get; set; }
    }
}
