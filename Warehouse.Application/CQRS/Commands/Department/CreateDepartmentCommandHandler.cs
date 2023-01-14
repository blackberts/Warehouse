using AutoMapper;
using MediatR;
using Warehouse.Application.CQRS.Commands.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;
using DepartmentEntity = Warehouse.Domain.Entities.Department;

namespace Warehouse.Application.CQRS.Commands.Department
{
    public class CreateDepartmentCommandHandler : BaseCommandHandler, IRequestHandler<CreateDepartmentCommand, DepartmentModel>
    {
        public CreateDepartmentCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<DepartmentModel> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var newDepartment = new DepartmentEntity
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            var departmentModel = await UnitOfWork.Department.CreateDepartmentAsync(newDepartment);
            
            if(departmentModel is null)
            {
                throw new ArgumentNullException("Something wrong when created department... ");
            }

            await UnitOfWork.SaveChangesAsync();

            return departmentModel;
        }
    }
}
