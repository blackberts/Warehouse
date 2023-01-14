using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Queries.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Department
{
    public class GetByIdDepartmentQueryHandler : BaseQueryHandler<GetByIdDepartmentQuery, DepartmentModel>
    {
        public GetByIdDepartmentQueryHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<DepartmentModel> ExecuteAsync(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
        {
            var departmentModel = await UnitOfWork.Department.GetByIdAsync(request.Id);

            if(departmentModel is null)
            {
                throw new ArgumentNullException("Cannot find department... ");
            }

            return departmentModel;
        }
    }
}
