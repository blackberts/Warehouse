using AutoMapper;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;
using WorkerEntity = Warehouse.Domain.Entities.Worker;

namespace Warehouse.Application.CQRS.Commands.Worker
{
    public class UpdateWorkerLastNameCommandHandler : BaseCommandHandler<UpdateWorkerLastNameCommand, WorkerModel>
    {
        public UpdateWorkerLastNameCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<WorkerModel> ExecuteAsync(UpdateWorkerLastNameCommand request, CancellationToken cancellationToken)
        {
            var workerModel = await UnitOfWork.Worker.GetByIdAsync(request.Id);

            if (workerModel is null)
            {
                throw new ArgumentNullException($"Cannot find worker with id... :  {request.Id}");
            }

            var workerEntity = new WorkerEntity
            {
                Id = workerModel.Id,
                FirstName = workerModel.FirstName,
                LastName = request.LastName,
                FullName = workerModel.FirstName + " " + request.LastName,
            };

            var updatedWorkerModel = await UnitOfWork.Worker.UpdateWorkerLastNameAsync(workerEntity);

            if (updatedWorkerModel is null)
            {
                throw new ArgumentNullException("Something wrong when updated first name worker... ");
            }
                
            await UnitOfWork.SaveChangesAsync();

            return updatedWorkerModel;
        }
    }
}
