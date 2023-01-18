using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Commands.Worker
{
    public class UpdateWorkerFirstNameCommand : IRequest<WorkerModel>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
    }
}
