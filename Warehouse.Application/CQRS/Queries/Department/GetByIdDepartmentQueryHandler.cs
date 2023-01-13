using AutoMapper;
using MediatR;
using Warehouse.Application.CQRS.Queries.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Department
{
    internal class GetByIdDepartmentQueryHandler : BaseQueryHandler, IRequestHandler<GetByIdDepartmentQuery, DepartmentModel>
    {
        public GetByIdDepartmentQueryHandler(IMapper mapper
            , IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<DepartmentModel> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
        {
            var departmentModel = await UnitOfWork.Department.GetByIdAsync(request.Id);

            if(departmentModel is null)
            {
                throw new ArgumentNullException("Cannot find department");
            }

            return departmentModel;
        }
    }
}
