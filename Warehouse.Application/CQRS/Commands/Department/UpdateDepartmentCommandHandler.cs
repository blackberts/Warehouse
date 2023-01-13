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
            var updateDepartment = new DepartmentEntity
            {
                Name = request.Name,
            };

            var departmentModel = await UnitOfWork.Department.UpdateDepartmentAsync(updateDepartment);

            if(departmentModel is null)
            {
                throw new ArgumentNullException(nameof(departmentModel));
            }

            await UnitOfWork.SaveChangesAsync();

            return departmentModel;
        }
    }
}
