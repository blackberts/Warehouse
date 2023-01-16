using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.CQRS.Commands.Department
{
    public class AssignWorkersToDepartmentCommandHandler : BaseCommandHandler<AssignWorkersToDepartmentCommand, Unit>
    {
        public AssignWorkersToDepartmentCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<Unit> ExecuteAsync(AssignWorkersToDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentModel = await UnitOfWork.Department.GetByIdAsync(request.DepartmentId);

            if(departmentModel is null)
            {
                throw new ArgumentNullException($"Cannot find department with id... : {request.DepartmentId}");
            }

            foreach(var workerId in request.WorkerIds)
            {
                var workerModel = await UnitOfWork.Worker.GetByIdAsync(workerId);

                if(workerModel is null)
                {
                    throw new ArgumentNullException($"Cannot find worker with id... : {workerId}");
                }

                var workerDepartments = new WorkersDepartments
                {
                    WorkerId = workerId,
                    DepartmentId = departmentModel.Id
                };

                UnitOfWork.WorkersDepartments.CreateDependencies(workerDepartments);
            }

            await UnitOfWork.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
