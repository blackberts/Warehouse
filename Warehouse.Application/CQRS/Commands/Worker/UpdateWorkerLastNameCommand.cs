using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Commands.Worker
{
    public class UpdateWorkerLastNameCommand : IRequest<WorkerModel>
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
    }
}
