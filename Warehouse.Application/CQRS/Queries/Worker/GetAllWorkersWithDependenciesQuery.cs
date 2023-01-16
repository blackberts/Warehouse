using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Worker
{
    public class GetAllWorkersWithDependenciesQuery : IRequest<List<WorkersDepartmentsModel>>
    {
    }
}
