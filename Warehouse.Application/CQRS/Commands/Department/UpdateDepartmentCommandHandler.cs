using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;
using DepartmentEntity = Warehouse.Domain.Entities.Department;

namespace Warehouse.Application.CQRS.Commands.Department
{
    public class UpdateDepartmentCommandHandler : BaseCommandHandler<UpdateDepartmentCommand, DepartmentModel>
    {
        public UpdateDepartmentCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<DepartmentModel> ExecuteAsync(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentModel = await UnitOfWork.Department.GetByIdAsync(request.Id);

            if(departmentModel is null)
            {
                throw new ArgumentNullException($"Cannot find department with id... : {request.Id} ");
            }

            var deparmentEntity = new DepartmentEntity
            {
                Id = departmentModel.Id,
                Name = request.Name,
            };

            var updatedDepartmentModel = await UnitOfWork.Department.UpdateDepartmentAsync(deparmentEntity);

            if(updatedDepartmentModel is null)
            {
                throw new ArgumentNullException("Something wrong when updated department... ");
            }

            await UnitOfWork.SaveChangesAsync();

            return updatedDepartmentModel;
        }
    }
}
