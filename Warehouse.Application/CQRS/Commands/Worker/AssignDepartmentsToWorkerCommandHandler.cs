using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Entities;

namespace Warehouse.Application.CQRS.Commands.Worker
{
    public class AssignDepartmentsToWorkerCommandHandler : BaseCommandHandler<AssignDepartmentsToWorkerCommand, Unit>
    {
        public AssignDepartmentsToWorkerCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<Unit> ExecuteAsync(AssignDepartmentsToWorkerCommand request, CancellationToken cancellationToken)
        {
            var workerModel = await UnitOfWork.Worker.GetByIdAsync(request.WorkerId);

            if(workerModel is null)
            {
                throw new ArgumentNullException($"Cannot find worker with id... : {request.WorkerId}");
            }

            foreach(var departmentId in request.DepartmentIds)
            {
                var departmentModel = await UnitOfWork.Department.GetByIdAsync(departmentId);

                if(departmentModel is null)
                {
                    throw new ArgumentNullException($"Cannot find department with id... : {departmentId}");
                }

                var workerDepartments = new WorkersDepartments
                {
                    WorkerId = request.WorkerId,
                    DepartmentId = departmentId
                };

                UnitOfWork.WorkersDepartments.CreateDependencies(workerDepartments);
            }

            await UnitOfWork.SaveChangesAsync();

            return await Task.FromResult(Unit.Value);
        }
    }
}
