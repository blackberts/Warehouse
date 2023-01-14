using AutoMapper;
using MediatR;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;
using DepartmentEntity = Warehouse.Domain.Entities.Department;

namespace Warehouse.Application.CQRS.Commands.Department
{
    public class UpdateDepartmentCommandHandler : BaseCommandHandler, IRequestHandler<UpdateDepartmentCommand, DepartmentModel>
    {
        public UpdateDepartmentCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<DepartmentModel> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentModel = await UnitOfWork.Department.GetByIdAsync(request.Id);

            if(departmentModel is null)
            {
                throw new ArgumentNullException("Cannot find department... ");
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
