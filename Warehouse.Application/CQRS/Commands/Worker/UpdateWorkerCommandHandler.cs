﻿using AutoMapper;
using MediatR;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;
using WorkerEntity = Warehouse.Domain.Entities.Worker;

namespace Warehouse.Application.CQRS.Commands.Worker
{
    public class UpdateWorkerCommandHandler : BaseCommandHandler, IRequestHandler<UpdateWorkerCommand, WorkerModel>
    {
        public UpdateWorkerCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<WorkerModel> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            var workerModel = await UnitOfWork.Worker.GetByIdAsync(request.Id);

            if (workerModel is null)
            {
                throw new ArgumentNullException("Cannot find worker... ");
            }

            var workerEntity = new WorkerEntity
            {
                Id = workerModel.Id,
                FirstName = workerModel.FirstName,
                LastName = workerModel.LastName,
                FullName = workerModel.FirstName + " " + workerModel.LastName,
            };

            var updatedWorkerModel = await UnitOfWork.Worker.UpdateWorkerAsync(workerEntity);

            if (updatedWorkerModel is null)
            {
                throw new ArgumentNullException("Something wrong when updated worker... ");
            }

            await UnitOfWork.SaveChangesAsync();

            return updatedWorkerModel;
        }
    }
}
