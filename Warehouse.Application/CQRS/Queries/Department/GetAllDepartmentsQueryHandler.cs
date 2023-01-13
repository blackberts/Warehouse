using AutoMapper;
using MediatR;
using Warehouse.Application.CQRS.Queries.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Department
{
    public class GetAllDepartmentsQueryHandler : BaseQueryHandler, IRequestHandler<GetAllDepartmentsQuery, List<DepartmentModel>>
    {
        public GetAllDepartmentsQueryHandler(IMapper mapper
            , IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<List<DepartmentModel>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var listOfModels = await UnitOfWork.Department.GetAllAsync();

            if(listOfModels is null || listOfModels.Count == 0)
            {
                throw new ArgumentNullException("Departments list is empty");
            }

            return listOfModels;
        }
    }
}
