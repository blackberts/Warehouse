using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;
using WorkerEntity = Warehouse.Domain.Entities.Worker;

namespace Warehouse.Application.CQRS.Commands.Worker
{
    public class CreateWorkerCommandHandler : BaseCommandHandler<CreateWorkerCommand, WorkerModel>
    {
        public CreateWorkerCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<WorkerModel> ExecuteAsync(CreateWorkerCommand request, CancellationToken cancellationToken)
        {
            var newWorker = new WorkerEntity
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                FullName = request.FirstName + " " + request.LastName,
            };

            var workerModel = await UnitOfWork.Worker.CreateWorkerAsync(newWorker);

            if (workerModel is null)
            {
                throw new ArgumentNullException("Something wrong when created worker... ");
            }

            await UnitOfWork.SaveChangesAsync();

            return workerModel;
        }
    }
}
