using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Department
{
    public class GetByIdDepartmentQuery : IRequest<DepartmentModel>
    {
        public Guid Id { get; set; }
    }
}
