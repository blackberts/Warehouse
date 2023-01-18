using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Worker
{
    public class GetAllWorkersQuery : IRequest<List<WorkerModel>>
    {
    }
}
