using MediatR;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Commands.Worker
{
    public class CreateWorkerCommand : IRequest<WorkerModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
