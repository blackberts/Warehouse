using AutoMapper;
using Microsoft.Extensions.Logging;
using Warehouse.Application.CQRS.Queries.Base;
using Warehouse.Application.UoW;
using Warehouse.Domain.Models;

namespace Warehouse.Application.CQRS.Queries.Product
{
    public class GetAllProductsWithDependenciesQueryHandler : BaseQueryHandler<GetAllProductsWithDependenciesQuery, List<ProductModel>>
    {
        public GetAllProductsWithDependenciesQueryHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger logger) : base(mapper, unitOfWork, logger)
        {
        }

        protected override async Task<List<ProductModel>> ExecuteAsync(GetAllProductsWithDependenciesQuery request, CancellationToken cancellationToken)
        {
            var listOfModels = await UnitOfWork.Product.GetAllWithDependenciesAsync();

            if (listOfModels is null || listOfModels.Count == 0)
            {
                throw new ArgumentNullException("Product list is empty... ");
            }

            return listOfModels;
        }
    }
}
