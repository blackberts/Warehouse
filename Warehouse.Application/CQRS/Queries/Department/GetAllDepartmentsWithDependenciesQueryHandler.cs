using AutoMapper;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Queries.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Department
{
    public class GetAllDepartmentsWithDependenciesQueryHandler : BaseQueryHandler<GetAllDepartmentsWithDependenciesQuery, List<WorkersDepartmentsModel>>
    {
        public GetAllDepartmentsWithDependenciesQueryHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<List<WorkersDepartmentsModel>> ExecuteAsync(GetAllDepartmentsWithDependenciesQuery request, CancellationToken cancellationToken)
        {
            var listOfModels = await UnitOfWork.WorkersDepartments.GetAllDepartmentsWithDependenciesAsync();

            if (listOfModels is null || listOfModels.Count == 0)
            {
                throw new ArgumentNullException("Department list is empty... ");
            }

            return listOfModels;
        }
    }
}
