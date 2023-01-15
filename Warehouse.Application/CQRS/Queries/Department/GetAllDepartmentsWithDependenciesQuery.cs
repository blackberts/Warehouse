using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Department
{
    public class GetAllDepartmentsWithDependenciesQuery : IRequest<List<DepartmentModel>>
    {
    }
}
