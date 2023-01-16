using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Commands.Worker
{
    public class DeleteWorkerCommandHandler : BaseCommandHandler<DeleteWorkerCommand, Unit>
    {
        public DeleteWorkerCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<Unit> ExecuteAsync(DeleteWorkerCommand request, CancellationToken cancellationToken)
        {
            UnitOfWork.WorkersDepartments.DeleteByIdWorker(request.Id);
            UnitOfWork.Worker.DeleteById(request.Id);

            await UnitOfWork.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
