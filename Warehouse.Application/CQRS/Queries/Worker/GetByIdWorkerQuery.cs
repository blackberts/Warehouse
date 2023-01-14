using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Worker
{
    public class GetByIdWorkerQuery : IRequest<WorkerModel>
    {
        public Guid Id { get; set; }
    }
}
