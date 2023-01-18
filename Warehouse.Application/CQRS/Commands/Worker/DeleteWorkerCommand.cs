using MediatR;

namespace Warehouse.Application.CQRS.Commands.Worker
{
    public class DeleteWorkerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
